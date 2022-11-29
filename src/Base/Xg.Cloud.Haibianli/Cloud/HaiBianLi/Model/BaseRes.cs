using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.HaiBianLi.Model
{
    public abstract class BaseRes
    {
        /// <summary>
        /// 请求返回码，判断请求是否成功  666：成功  444：失败
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 结果返回码，判断 api 是否执行成功 666：成功  444：失败---判断这个就行，不用管ReturnCode
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public dynamic ResultMsg { get; set; }
    }
}
