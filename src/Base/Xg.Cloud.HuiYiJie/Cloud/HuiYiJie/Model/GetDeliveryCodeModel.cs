using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.HuiYiJie.Model
{
    public class GetDeliveryCodeReq
    {
        /// <summary>
        /// 商品总数量（明细里的商品数量之和，上限8个）
        /// </summary>
        public int GoodsNumber { get; set; }
        /// <summary>
        /// 传售货机 ID 只能在此 ID 的售货机上使用；传 0 能在 商户名下所有机器使用
        /// </summary>
        public long MachineUuid { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 订单时间格式为”2019-05-07T07:03:33.970Z”
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 1-锁定(非必 填)
        /// </summary>
        public int Lock { get; set; }
        /// <summary>
        /// 超时时长，以小时为单位。
        /// </summary>
        public int TimeOut { get; set; }

        public List<GetDeliveryCodeGoods> GoodsList { get; set; }
    }

    public class GetDeliveryCodeRes: BaseRes
    {
        /// <summary>
        /// 取货码
        /// </summary>
        public string Data { get; set; }
    }

    public class GetDeliveryCodeGoods
    {
        /// <summary>
        /// 商品数量
        /// </summary>
        public int GoodsNumber { get; set;}
        /// <summary>
        /// 商品价格
        /// </summary>
         public double GoodsPrice { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public long GoodsUuid { get; set; }
    }

    public class DeliverySuccessNotify
    {
        /// <summary>
        /// 售货机ID
        /// </summary>
        public string Mid { get; set;}
        /// <summary>
        /// 售货机名称
        /// </summary>
        public string Mname { get; set; }
        /// <summary>
        /// 取货码
        /// </summary>
        public string PickCode { get; set; }
        /// <summary>
        /// 货道
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// 机柜
        /// </summary>
        public string Cib { get; set; }
        /// <summary>
        /// 出货时间
        /// </summary>
        public string OutTime { get; set; }
        /// <summary>
        /// 出货状态：0未出货 1出货中 2出货成 功 3出货失败 4取消出货5出货异常
        /// </summary>
        public string OutState { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 出货数量
        /// </summary>
        public string GoodsNum { get; set; }
        /// <summary>
        /// 使用状态：0未使用1已使用
        /// </summary>
        public string UseState { get; set; }
    }
}
