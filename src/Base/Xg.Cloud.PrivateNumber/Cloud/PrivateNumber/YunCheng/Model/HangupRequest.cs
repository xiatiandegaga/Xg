using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.PrivateNumber.YunCheng.Model
{
    public class HangupRequest
    {
        /// <summary>
        /// 全局唯一呼叫ID
        /// </summary>
        public string CallId { get; set; }
        /// <summary>
        /// 针对中间号码与主被叫号码唯一的绑 定Id
        /// </summary>
        public string BindId { get; set; }
        /// <summary>
        /// 用户在平台的唯一标识
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 通话主叫号码必须为11位手机号如：13631686024
        /// </summary>
        public string Caller { get; set; }
        /// <summary>
        /// 通话被叫号码必须为11位手机号如：13631686024
        /// </summary>
        public string Callee { get; set; }
        /// <summary>
        /// 被叫侧显号
        /// </summary>
        public string CalleeDisplay { get; set; }
        /// <summary>
        /// 中间号码/号码X 必须为11位手机号 如：13631686024
        /// </summary>
        public string PrivacyNum  { get; set; }
        /// <summary>
        /// 用户透传数据
        /// </summary>
        public string UserData { get; set; }
        /// <summary>
        /// 是否录音 0：不录音 1：录音【默认为0】
        /// </summary>
        public string Record { get; set; }
        /// <summary>
        /// 表示本次呼叫中的Caller角色0：主叫 1：被叫
        /// </summary>
        public string Flag { get; set; }
        /// <summary>
        /// 通话时长(秒)
        /// </summary>
        public string CallTime { get; set; }
        /// <summary>
        /// 呼叫开始时间/yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// 呼叫结束时间/yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 通话最后状态：0：主叫正常挂机 1：被叫正常挂机 2：用户忙/被叫 3：用户未响应/被叫 4：用户未应答/被叫 5：用户拒接/被叫（被叫处于关机、飞行模式、无网络等状态） 6：平台释放(被叫号码不存在，呼叫不可达)
                /// </summary>
        public string CallStatus { get; set; }
    }
}
