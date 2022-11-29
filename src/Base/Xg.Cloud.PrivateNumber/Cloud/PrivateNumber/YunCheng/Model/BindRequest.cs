using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.PrivateNumber.YunCheng.Model
{
    public class BindRequest
    {
        /// <summary>
        /// 主叫号码/号码A必须为11位手机号如：13631686024
        /// </summary>
        public string Caller { get; set; }
        /// <summary>
        /// 中间号/号码X 如果不填平台自动分配用户所属的X 号码 必须为11位手机号如：13631686024
        /// </summary>
        public string PrivacyNum { get; set; }
        /// <summary>
        /// 是否录音 0：不开通录音功能 1：开通录音功能【默认为0】
        /// </summary>
        public string Record { get; set; }
        /// <summary>
        /// 来显控制 【默认为0】 0：A呼叫X和B呼叫X，被叫显示的主叫号码都是X号 码。1：A呼叫X时，被叫B显示的号码是A。 2：B呼叫X时，被叫A显示的号码是B。 3：A呼叫X时，被叫B显示的号码是A；B呼叫X时，被叫A显示的号码是B。
        /// </summary>
        public string CallDisplay { get; set; }
        /// <summary>
        /// 用户透传数据，最大不超过128个字节，回调通知中原样带回
        /// </summary>
        public string UserData { get; set; }
        /// <summary>
        ///通话状态回调地址,如未指定需向平台人员提供相应的接收地址
        /// </summary>
        public string StatusUrl { get; set; }
        /// <summary>
        ///挂机话单回调地址,如未指定需向平台人员提供相应的接收地址
        /// </summary>
        public string HangupUrl { get; set; }
        /// <summary>
        ///通话录音回调地址,如未指定需向平台人员提供相应的接收地址
        /// </summary>
        public string RecordUrl { get; set; }
    }
}
