using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.HaiBianLi.Model
{
    public class ChangeDeviceGoodStatusModel
    {
        /// <summary>
        /// 设备 ID，（支持批量 用","隔开的ID字
        /// </summary>
        public string DeviceCode { get; set; }

        /// <summary>
        /// 设备 ID，（支持批量 用","隔开的ID字
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// 商品编号(云库)，（支持批量 用","隔开的ID字)
        /// </summary>
        public string GoodId { get; set; }
        /// <summary>
        /// 1 上架 2 下架
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 用来生成签名
        /// </summary>
        public string NonceStr { get; set; }
        /// <summary>
        /// 请求序列号
        /// </summary>
        public string RequestSerial { get; set; }
        /// <summary>
        ///请求时间
        /// </summary>
        public long TimeStamp { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
    }
}
