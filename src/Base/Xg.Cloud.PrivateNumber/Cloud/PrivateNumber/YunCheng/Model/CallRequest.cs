using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.PrivateNumber.YunCheng.Model
{
    public class CallRequest
    {
        /// <summary>
        /// 绑定ID
        /// </summary>
        public string BindId { get; set; }
        /// <summary>
        /// 中间号/号码X 必须为11位手机号如：13631686024
        /// </summary>
        public string PrivacyNum  { get; set; }
        /// <summary>
        /// 被叫号码必须为11位手机号如：13631686024
        /// </summary>
        public string Callee { get; set; }
        /// <summary>
        /// 外呼类型 1：语音 2:短信 不传值默认为语音外呼
        /// </summary>
        public string CallType { get; set; }
        /// <summary>
        /// 用户透传数据，最大不超过128个字节，回调通知中原样带回
        /// </summary>
        public string UserData { get; set; }
    }
}
