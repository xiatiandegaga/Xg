using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    [Table(Name = "bus_pointFlow")]
    public class PointFlow
    {

        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
	    /// 流水号
	    /// </summary>
        public string FlowNo { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>


        public long UserId { get; set; }
        /// <summary>
	    /// 积分变动值
	    /// </summary>
        public int VarPoint { get; set; }
        /// <summary>
	    /// 增加还是减少（1：增加 0：减少）
	    /// </summary>
        public sbyte AddOrMinus { get; set; }
        /// <summary>
        /// 流水来源类型（1：咖啡订单表 2：积分商城订单表 3：积分发放工单表 4：走廊值兑换 5:活动获取，6后台积分发放 7抢红包 8食堂补餐 9合作伙伴定点登录发放积分 10砍价商品兑换 12 绚集商城订单表 13 绚集积分发放工单表 15绚集活动 ）
        /// </summary>
        public int SourceCtrgId { get; set; }

        /// <summary>
        /// 流水来源ID
        /// </summary>

        public long SourceId { get; set; }
        /// <summary>
	    /// 流水来源单号
	    /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
	    /// 创建时间
	    /// </summary>
        public System.DateTime CreateDate { get; set; }
        /// <summary>
	    /// 类型
	    /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
	    /// 类型名称
	    /// </summary>
        public string TypeName { get; set; }


    }
    [Table(Name = "sys_user")]
    public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        public int MemberPoint { get; set; }
    }
}
