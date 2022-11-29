using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.HuiYiJie.Model
{

    public class GetTokenReq
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    public class GetTokenRes: BaseRes
    {
        /// <summary>
        /// token
        /// </summary>
        public string Data { get; set; }
    }
       
}
