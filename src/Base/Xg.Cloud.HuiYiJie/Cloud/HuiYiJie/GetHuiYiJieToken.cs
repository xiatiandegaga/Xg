using Cloud.Caching;
using Cloud.HuiYiJie.Model;
using Cloud.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Cloud.HuiYiJie
{
    public class GetHuiYiJieToken
    {
        private readonly IApiVendingMachine _apiVendingMachine;
        private readonly IConfiguration _configuration;
        private readonly ICache _cache;
        public GetHuiYiJieToken(IApiVendingMachine apiVendingMachine, IConfiguration configuration, ICache cache)
        {
            _apiVendingMachine = apiVendingMachine;
            _configuration = configuration;
            _cache = cache;
        }

        /// <summary>
        /// 获取api的token
        /// </summary>
        /// <returns></returns>

        public async Task<string> GetToken()
        {
            string tokenKey = _configuration["HuiJieYi:TokenKey"];
            if (!string.IsNullOrWhiteSpace(tokenKey) && await _cache.ExistsAsync(tokenKey))
            {
                return await _cache.GetAsync<string>(tokenKey);
            }
            return await ReGetTokenAsync();
        }

        /// <summary>
        /// 重置状态码
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MyException"></exception>
        public async Task<string> ReGetTokenAsync()
        {
            string userName = _configuration["HuiJieYi:Account"];
            string password = _configuration["HuiJieYi:Password"];
            string tokenKey = _configuration["HuiJieYi:TokenKey"];

            var req = await _apiVendingMachine.GetTokenAsync(new GetTokenReq { UserName = userName, Password = password });
            if (req.Result != "200")
            {
                throw new MyException($"盲盒机登录失败：状态码:{req.Result}，失败信息:{req.ResultDesc}");
            }

            await _cache.SetFreeTimeAsync(tokenKey, req.Data, new TimeSpan(6 * 24, 0, 0), false);
            return req.Data;
        }
    }
}
