using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.HaiBianLi.Model
{
    public class HaiBianLiGoodModel
    {
        /// <summary>
        /// 云库商品 id
        /// </summary>
        public long GoodsId { get; set; }
        /// <summary>
        /// 一维条码
        /// </summary>
        public long? Barcode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 状态 1 上架 2 下架
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal? RawPrice { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
