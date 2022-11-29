using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.PrivateNumber.YunCheng.Model
{
    public class HangupResponse
    {
        /// <summary>
        /// 接收响应反馈: 1、接收成功 0、接收失败；接收失败平台会每隔两分钟推送一次 推送
        /// </summary>
        public int Result { get; set; }
    }
}
