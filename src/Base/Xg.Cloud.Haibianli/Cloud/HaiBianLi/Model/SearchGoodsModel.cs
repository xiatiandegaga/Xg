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
using WebApiClientCore.Serialization;

namespace Cloud.HaiBianLi
{
    public class SearchGoodsModel
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodName { get; set; }
        /// <summary>
        /// 商品内部id
        /// </summary>
        public long? GoodId { get; set; }
        /// <summary>
        /// 一维条码
        /// </summary>
        public long? Barcode { get; set; }
        /// <summary>
        /// 开始下标
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// 获取个数（最大500）
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
        public int CompanyId { get; set; }
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
        public string TimeStamp { get; set; }
        /// <summary>
        /// 1标品 2非标品  （标品指的是，有些商品不好识别，我们要帮忙识别）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

    }
}
