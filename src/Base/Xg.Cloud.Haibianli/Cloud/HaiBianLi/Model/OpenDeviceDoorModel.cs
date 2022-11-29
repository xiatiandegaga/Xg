using Cloud.Extensions;
using Cloud.Models;
using Cloud.Utilities;
using Cloud.Utilities.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore;
using WebApiClientCore.HttpContents;

namespace Cloud.HaiBianLi.Model
{
    public class OpenDeviceDoorModel
    {
        /// <summary>
        /// 用户 ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 设备编码
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// 用户类型,0 未知，1 用户，2 补货员
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 用来生成签名
        /// </summary>
        public string NonceStr { get; set; }
        /// <summary>
        /// 请求序列号
        /// </summary>
        public string RequestSerial { get; set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public long TimeStamp { get; set; }
        /// <summary>
        /// 支付类型 0-未知，1-支付宝代扣，2-微信代扣，3-支付宝手工，4-微信手工，5-支付宝扫码，6-支付宝刷脸，7-微信扫码，8-微信刷脸
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        public Task OnRequestAsync(ApiParameterContext context)
        {
            var config = (IConfiguration)context.HttpContext.ServiceProvider.GetService(typeof(IConfiguration));
            if (config == default)
                throw new MyException($"{nameof(SearchGoodsModel)} 不可为空",0);
            var nonceStr = config["RemoteServices:CloudHaiBianLi:NonceStr"];
            var companyId = config["RemoteServices:CloudHaiBianLi:CompanyId"];
            var deviceCode = config["RemoteServices:CloudHaiBianLi:DeviceCode"];
            string timeSpan = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.NonceStr = nonceStr;
            this.TimeStamp = timeSpan.ToInt();
            this.RequestSerial = timeSpan;
            this.PayType = 0;
            var waitSign = $"{ApiSignUtility.GetSortParam(JsonUtility.Serialize(this))}";
            this.Sign = EncryptionUtility.MD5(waitSign).ToUpper();

            var options = context.HttpContext.HttpApiOptions.JsonSerializeOptions;
            context.HttpContext.RequestMessage.Content = new JsonContent(this, options);
            return Task.CompletedTask;
        }
    }
}
