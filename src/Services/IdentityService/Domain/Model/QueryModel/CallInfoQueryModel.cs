using Cloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CallInfoQueryModel : Pagination
    {
        /// <summary>
        /// 被叫用户
        /// </summary>
        public string UserKeyWord { get; set; }

        /// <summary>
        /// 拨出用户
        /// </summary>
        public string ReferKeyWord { get; set; }
        /// <summary>
        /// 呼叫开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 呼叫截止时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 播出状态
        /// </summary>
        public string CallStatus { get; set; }
    }
}
