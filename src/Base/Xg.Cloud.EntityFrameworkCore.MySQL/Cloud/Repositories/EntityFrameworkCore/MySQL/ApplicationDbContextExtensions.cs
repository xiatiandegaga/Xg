using Cloud.EntityFrameworkCore;
using Cloud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Repositories.EntityFrameworkCore.MySQL
{
    public static class ApplicationDbContextExtensions
    {
        public static async Task<IList<T>> SqlQueryAsync<T>(this ApplicationDbContext db, StringBuilder sql, Pagination pagination = null, params object[] parameters)
           where T : new()
        {
            //注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常
            var conn = db.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            using var command = conn.CreateCommand();
            if (pagination != null)
            {
                sql.Append(" limit @skip,@take ");
                var skipParam = new MySqlParameter("@skip", SqlDbType.Int) { Value = (pagination.PageIndex - 1) * pagination.PageSize };
                var takeParam = new MySqlParameter("@take", SqlDbType.Int) { Value = pagination.PageSize };
                command.Parameters.Add(skipParam);
                command.Parameters.Add(takeParam);
            }
            command.CommandText = sql.ToString();
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            var propts = typeof(T).GetProperties();
            var rtnList = new List<T>();
            T model;
            object val;
            using (var reader = await command.ExecuteReaderAsync())
                while (reader.Read())
                {
                    model = new T();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        foreach (var l in propts)
                        {
                            if (l.SetMethod == null || l.Name.ToLower() != reader.GetName(i).ToLower()) continue;

                            val = reader[l.Name];
                            if (val == DBNull.Value)
                            {
                                l.SetValue(model, null);
                            }
                            else
                            {
                                l.SetValue(model, val);
                            }
                        }
                    }


                    rtnList.Add(model);
                }

            return rtnList;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        public static void ExecProcedure(this ApplicationDbContext db, string sql, IDbContextTransaction tran = null, params MySqlParameter[] parameters)
        {
            //注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常
            if (tran != null)
            {
                using var command = tran.GetDbTransaction().Connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }
            else
            {
                var conn = db.Database.GetDbConnection();
                try
                {
                    conn.Open();
                    using var command = conn.CreateCommand();
                    command.CommandText = sql;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }

        }

    }
}
