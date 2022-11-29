using Cloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MyQueryModel : Pagination
    {
        /// <summary>
        /// 标签id列表
        /// </summary>
        public List<long> LabelIdList { get; set; }
        /// <summary>
        /// 查询关键字
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// call客用户来源
        /// </summary>
        public string CallKeSourceFrom { get; set; }
    }
}
