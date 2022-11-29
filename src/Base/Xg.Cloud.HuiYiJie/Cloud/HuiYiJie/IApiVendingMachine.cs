
using Cloud.HuiYiJie.Model;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;


namespace Cloud.HuiYiJie
{
    public interface IApiVendingMachine : IApiService
    {
        /// <summary>
        /// 获取api的token
        /// </summary>
        /// <param name="request">请求报文</param>
        /// <returns></returns>
        [HttpGet("/apiusers/checkusername/")]

        Task<GetTokenRes> GetTokenAsync(GetTokenReq request);

        /// <summary>
        /// 获取售货机商品信息
        /// </summary>
        /// <param name="request">请求报文</param>
        /// <returns></returns>
        [HttpGet("/customgoods/querymachinegoods/")]
        [YunChengHeaderFilter]
        Task<GetMachineGoodsRes> GetMachineGoodsAsync(GetMachineGoodsReq request);

        /// <summary>
        /// 查询售货机库存接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/commodityinfo/queryGoodsStock/")]
        [YunChengHeaderFilter]
        Task<GoodsStockRes> QueryGoodsStockAsync(GetMachineGoodsReq request);
        /// <summary>
        /// 获取取货码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/commpick/productionpick/")]
        [YunChengHeaderFilter]
        Task<GetDeliveryCodeRes> GetDeliveryCodeAsync([JsonContent] GetDeliveryCodeReq request);


        /// <summary>
        /// 作废取货码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/commpick/cancalPick/")]
        [YunChengHeaderFilter]
        Task<BaseRes> CancelPickAsync([JsonContent] PickCodeModel request);
        //[HttpPost("/rest/v3/voice/ax/queryByUserId/")]
        //Task<QueryByUserIdResponse> QueryByUserId([JsonContent] QueryByUserIdRequest request);
    }
}
