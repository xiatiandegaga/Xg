using Cloud.Extensions;
using Cloud.Models;
using Cloud.Utilities;
using Cloud.Utilities.Json;
using Cloud.PrivateNumber.YunCheng.Model;
using Microsoft.Extensions.Configuration;
using RSAExtensions;
using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore;
using WebApiClientCore.Attributes;

namespace Cloud.PrivateNumber.YunCheng
{
    public class YunChengHeaderFilterAttribute : ApiActionAttribute
    {

        public override Task OnRequestAsync(ApiRequestContext context)
        {
            var config = (IConfiguration)context.HttpContext.ServiceProvider.GetService(typeof(IConfiguration));
            if(config==default)
                throw new MyException($"{nameof(YunChengHeaderFilterAttribute)} 不可为空",0);
            var header = new YunChengRequestHeader
            {
                Token= config["PrivateNumber:YunCheng:Token"],
                Timestamp= TimeExtension.CurrentTimeMillis().ToString(),
                UserId= config["PrivateNumber:YunCheng:UserId"]
            };
            context.HttpContext.RequestMessage.Headers.Add("Token", header.Token);
            context.HttpContext.RequestMessage.Headers.Add("Timestamp", header.Timestamp);
            var pubKey= config["PrivateNumber:YunCheng:PubKey"];
            if (string.IsNullOrEmpty(pubKey))
                throw new MyException("PrivateNumber:YunCheng:PubKey为空");
            var signParams = JsonUtility.Serialize(header);
            var sign = new RsaUtility(RSAType.RSA, Encoding.UTF8, null, pubKey).Encrypt(signParams);
            context.HttpContext.RequestMessage.Headers.Add("Sign", sign);
            context.HttpContext.RequestMessage.RequestUri = new Uri(context.HttpContext.RequestMessage.RequestUri+ header.UserId);
            return Task.CompletedTask;
        }
    }
}
