using Cloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UserOwnerQueryModel: Pagination
    {
        /// <summary>
        /// 业主名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 业主手机号
        /// </summary>
        public string UserMobile { get; set; }
        /// <summary>
        /// 是否已匹配(1已匹配）
        /// </summary>
        public int? IsMatch { get; set; }

        /// <summary>
        /// 是否已注册
        /// </summary>
        public int? IsRegister { get; set; }
    }
}
