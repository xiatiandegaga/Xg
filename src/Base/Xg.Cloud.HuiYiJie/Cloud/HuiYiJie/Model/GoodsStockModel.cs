using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.HuiYiJie.Model
{
    /// <summary>
    /// 售货机商品库存
    /// </summary>
    public class GoodsStockRes:BaseRes
    {
        public List<GoodsStockModel> Data { get; set; }
    }

    public class GoodsStockModel
    {
        /// <summary>
        /// 平台库存ID
        /// </summary>
        public long Uuid { get; set; }

        /// <summary>
        /// 平台库存ID
        /// </summary>
        public long MachineUuid { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public long GoodsUuid { get; set; }

        /// <summary>
        /// 上架库存
        /// </summary>
        public long Inventory { get; set; }

        /// <summary>
        /// 可售库存
        /// </summary>
        public long AvailableInventory { get; set; }

        /// <summary>
        /// 锁定库存
        /// </summary>
        public long? LockInventory { get; set; }

        /// <summary>
        /// 销售价格
        /// </summary>
        public double SalesPrice { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public long? CreateUserUuid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新用户ID
        /// </summary>
        public long? ModifyUserUuid { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime? EffStartTime { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime? EffEndTime { get; set; }
    }
}
