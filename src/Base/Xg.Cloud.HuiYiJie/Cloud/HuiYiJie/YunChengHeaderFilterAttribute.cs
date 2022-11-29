using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebApiClientCore;
using WebApiClientCore.Attributes;


namespace Cloud.HuiYiJie
{
    public class YunChengHeaderFilterAttribute : ApiActionAttribute
    {
        public override Task OnRequestAsync(ApiRequestContext context)
        {
            var getHuiYiJieToken = ((GetHuiYiJieToken)context.HttpContext.ServiceProvider.GetService(typeof(GetHuiYiJieToken)));
            var token= getHuiYiJieToken.GetToken().Result;
            context.HttpContext.RequestMessage.Headers.Add("Authorization", token);
            //var token1 = config.GetToken();
            //var token = _getHuiYiJieToken.GetToken();
            //var header = new YunChengRequestHeader
            //{
            //    Token= config["PrivateNumber:YunCheng:Token"],
            //    Timestamp= TimeExtension.CurrentTimeMillis().ToString(),
            //    UserId= config["PrivateNumber:YunCheng:UserId"]
            //};
            //context.HttpContext.RequestMessage.Headers.Add("Token", header.Token);
            //context.HttpContext.RequestMessage.Headers.Add("Authorization", "ss");
            //context.HttpContext.RequestMessage.Headers.Add("Timestamp", header.Timestamp);
            //var pubKey= config["PrivateNumber:YunCheng:PubKey"];
            //if (string.IsNullOrEmpty(pubKey))
            //    throw new MyException("PrivateNumber:YunCheng:PubKey为空");
            //var signParams = JsonUtility.Serialize(header);
            //var sign = new RsaUtility(RSAType.RSA, Encoding.UTF8, null, pubKey).Encrypt(signParams);
            //context.HttpContext.RequestMessage.Headers.Add("Sign", sign);
            //context.HttpContext.RequestMessage.RequestUri = new Uri(context.HttpContext.RequestMessage.RequestUri+ header.UserId);
            return Task.CompletedTask;
        }
    }
}
