using Cloud.Snowflake;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tool
{
    [Table(Name = "temp_mobile")]
    class Temp_Mobile
    {
        public string Mobile { get; set; }
    }

    [Table(Name = "temp_mobile_copy2")]
    class Temp_Mobile_Copy2
    {
        public string Mobile { get; set; }
        public string New { get; set; }
    }

    [Table(Name = "task_mqInfo")]
    class Task_MqInfo
    {
        public long Id { get; set; }
        /**
       * 队列任务名称
       */
        public string MqName { get; set; }

        /**
         * 队列任务代号
         */
        public string MqCode { get; set; }

        /**
         * 队列任务model全名
         */
        public string MqExchangeType { get; set; }

        /**
         * 队列任务model全名
         */
        public string MqModelName { get; set; }

        /**
         * 队列任务接口url
         */
        public string MqAction { get; set; }

        /**
         * 队列消费者默认每次消费数量（建议3，如果是秒杀这种，填5或以上）
         */
        public string MqConsumePrefetchCount { get; set; }

        /**
         * 队列消费者数量（建议3，如果是秒杀这种，填10或以上）
         */
        public int MqConsumeCount { get; set; }

        /**
         * 备注
         */
        public string Remark { get; set; }

        /**
         * 状态（0：无效  1：有效）
         */
        public int Status { get; set; }
    }


    [Table(Name = "task_project")]
    class Task_project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }


    [Table(Name = "task_projectMq")]
    class Task_projectMq
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long MqInfoId { get; set; }
    }
    class Program
    {
        private static HashSet<string> set = new HashSet<string>();
        static void Main(string[] args)
        {
            //         IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            //.UseConnectionString(FreeSql.DataType.MySql, "server=xxxx;userid=root;pwd=xxxx;port=3306;database=xxxx;sslmode=none;TreatTinyAsBoolean=false;")
            //.Build(); //请务必定义成 Singleton 单例模式
            //var listOldMobile = fsql.Select<Temp_Mobile>().ToList();
            //List<Temp_Mobile_Copy2> listMobile = new List<Temp_Mobile_Copy2>();
            //listOldMobile.ForEach(x =>
            //{
            //    x.Mobile.Split(';').ToList().ForEach(s =>
            //    {
            //        if (s != null && s != "" && s.Length > 3)
            //            if (set.Contains(s))
            //            {

            //            }
            //            else
            //            {
            //                set.Add(s);
            //                if (s.Length == 11)
            //                    listMobile.Add(new Temp_Mobile_Copy2 { Mobile = s });
            //            }

            //    });
            //});
            //var t2 = fsql.Insert(listMobile).ExecuteAffrows();

            ClearPointTask();
        }
        static void UpdateMqTask()
        {
            var snowflakeIdWorkerInstance = new SnowflakeIdWorker(0, 0);
            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
   .UseConnectionString(FreeSql.DataType.MySql, "server=xxxx;userid=root;pwd=xxxx;port=33061;database=asset;sslmode=none;TreatTinyAsBoolean=false;")
   .Build(); //请务必定义成 Singleton 单例模式
            var listTaskProject = fsql.Select<Task_project>().Where(x=>x.Name=="22").ToList();
            var listTaskMq = fsql.Select<Task_MqInfo>().ToList();
            List<Task_projectMq> listTaskProjectMq = new List<Task_projectMq>();
            listTaskProject.ForEach(x =>
            {
                listTaskMq.ForEach(s =>
                {
                    var taskProjectMq = new Task_projectMq();
                    taskProjectMq.Id = snowflakeIdWorkerInstance.NextId();
                    taskProjectMq.ProjectId = x.Id;
                    taskProjectMq.MqInfoId = s.Id;
                    listTaskProjectMq.Add(taskProjectMq);
                });
            });
            var t2 = fsql.Insert(listTaskProjectMq).ExecuteAffrows();
        }


        static void ClearPointTask()
        {
            var snowflakeIdWorkerInstance = new SnowflakeIdWorker(0, 0);
            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
   .UseConnectionString(FreeSql.DataType.MySql, "server=xxxx;userid=root;pwd=xxxx;port=3306;database=xxxx;sslmode=none;TreatTinyAsBoolean=false;")
   .Build(); //请务必定义成 Singleton 单例模式
            var listUser = fsql.Select<User>().ToList();
            List<PointFlow> listPointFlow = new();
            listUser.ForEach(x =>
            {
                PointFlow pointFlow = new();
                pointFlow.Id = snowflakeIdWorkerInstance.NextId();
                pointFlow.VarPoint = x.MemberPoint;
                pointFlow.AddOrMinus = 0;
                pointFlow.CreateDate=DateTime.Now;
                pointFlow.SourceCtrgId = -1;
                pointFlow.SourceId = 0;
                pointFlow.OrderNo = string.Empty;
                pointFlow.TypeCode = "YearEndPointReset";
                pointFlow.TypeName = "年底积分清零";
                pointFlow.FlowNo = $"PF{snowflakeIdWorkerInstance.NextId()}";
                pointFlow.UserId = x.Id;
                listPointFlow.Add(pointFlow);
            });
            fsql.Transaction(() =>
            {

                var t2 = fsql.Insert(listPointFlow).ExecuteAffrows();
                var ret1 = fsql.Ado.ExecuteNonQuery("update sys_user set memberpoint=0 where id>100");
            });
        }


    }
}
