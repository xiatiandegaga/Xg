using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Shared.Model.QueryModel
{
    public class CacheDeleteQuery
    {
        /// <summary>
        /// 缓存类全称（带命名空间）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否实体缓存1：是 0：列表缓存
        /// </summary>
        public int IsEntity { get; set; }

        /// <summary>
        /// 实体缓存主键id
        /// </summary>

        public string PrimaryKey { get; set; }



    }
}
