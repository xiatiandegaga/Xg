using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.HuiYiJie.Model
{
    public class GetMachineGoodsReq
    {
        /// <summary>
        /// 售货机id
        /// </summary>
        public long MachineUuid { get; set; }
    }

    public class GetMachineGoodsRes : BaseRes
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public List<VendingMachineGoodsInfo> Data { get; set; }
    }

    public class VendingMachineGoodsInfo
    {
        public CommGoodsModel CommGoodsModel { get; set; }

        public List<VendingMachineGoods> GoodsList { get; set; }
    }

    public class CommGoodsModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Uuid { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 类型名称描述
        /// </summary>
        public string TypeRemark { get; set; }
        /// <summary>
        /// 售货机类型
        /// </summary>
        public string MachineUuid { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public string CustomType { get; set; }
 
    }
        public  class  VendingMachineGoods
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Uuid { get; set; }

        /// <summary>
        ///
        /// </summary>
        public long CateUuid { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public long? GoodsType { get; set; }

        /// <summary>
        ///商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品url
        /// </summary>
        public string GoodsUrl { get; set; }

        /// <summary>
        /// 商品code
        /// </summary>
        public string GoodsCode { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public double? GoodsPrice { get; set; }

        /// <summary>
        /// 会员价
        /// </summary>
        public double? MembersPrice { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public double? CostPrice { get; set; }

        /// <summary>
        ///插入时间
        /// </summary>
        public string InsertTime { get; set; }
        /// <summary>
        /// 产品url
        /// </summary>
        public string IntroduceUrl { get; set; }

        /// <summary>
        /// 商品备注
        /// </summary>
        public string GoodsRemark { get; set; }

        /// <summary>
        /// 机器id
        /// </summary>
        public long? MachineUuid { get; set; }
        /// <summary>
        /// 商品类型说明
        /// </summary>
        public int? GoodsTypeStr { get; set; }

        /// <summary>
        /// 创建人id
        /// </summary>
        public long? CreateUserUuid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 修改人id
        /// </summary>
        public long? ModifyUserUuid { get; set; }

        /// <summary>
        /// 修改人时间
        /// </summary>
        public string ModifyTime { get; set; }
        /// <summary>
        /// 生效开始时间
        /// </summary>
        public string EffStartTime { get; set; }

        /// <summary>
        /// 生效结束时间
        /// </summary>
        public string EffEndTime { get; set; }

        /// <summary>
        /// 上级商户ID
        /// </summary>
        public long? FatherUserUuid { get; set; }

    }
}
