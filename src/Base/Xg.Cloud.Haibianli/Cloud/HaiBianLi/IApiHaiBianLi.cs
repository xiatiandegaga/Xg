using Cloud.HaiBianLi.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;

namespace Cloud.HaiBianLi
{
    public interface IApiHaiBianLi: IApiService
    {
        /// <summary>
        /// 查询商品是否在云库
        /// </summary>
        /// <param name="request">请求报文</param>
        /// <returns></returns>
        [LoggingFilter]
        [HttpPost("/api-node-oldapi/hiApi/searchGoods")]

        Task<SearchGoodsReturnModel> SearchGoods([FormContent]SearchGoodsModel request);


        /// <summary>
        /// 扫码开门
        /// </summary>
        /// <param name="request">请求报文</param>
        /// <returns></returns>
        [LoggingFilter]
        [HttpPost("/api-node-oldapi/hiApi/openDeviceDoor/")]

        Task<OpenDeviceDoorReturnModel> OpenDeviceDoor([FormContent] OpenDeviceDoorModel request);


        /// <summary>
        /// 批量上下架
        /// </summary>
        /// <param name="request">请求报文</param>
        /// <returns></returns>
        [LoggingFilter]
        [HttpPost("/api-node-oldapi/hiApi/changeDeviceGoodStatus/")]

        Task<OpenDeviceDoorReturnModel> ChangeDeviceGoodStatus([FormContent] ChangeDeviceGoodStatusModel request);

    }
}
