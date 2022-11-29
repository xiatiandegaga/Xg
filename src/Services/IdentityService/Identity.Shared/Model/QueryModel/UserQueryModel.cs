using Cloud.Models;
using System;

namespace Identity.Shared.Model.QueryModel
{
    public   class UserQueryModel: Pagination
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 用户部门id
        /// </summary>
        public long DeptId { get; set; }

        /// <summary>
        /// 上级用户id（转发人）
        /// </summary>

        public long Pid { get; set; }

        /// <summary>
        /// 推荐用户id
        /// </summary>

        public long ReferId { get; set; }
        /// <summary>
        /// 推荐用户部门id
        /// </summary>

        public long ReferDeptId { get; set; }
        /// <summary>
        /// 用户来源
        /// </summary>
        public long? SourceFrom { get; set; }

        /// <summary>
        /// 首次门店
        /// </summary>
        public long FirstFieldId { get; set; }
        /// <summary>
        /// 是否非业务员客户
        /// </summary>
        public int? IsNoReferCus { get; set; }
        /// <summary>
        /// 注册开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 注册截止日期
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 海报类型
        /// </summary>
        public string PostersType { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string WorkUnitCode { get; set; }
    }
}
