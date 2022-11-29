using Cloud.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserModel : BaseEntity<long>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 姓名昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string SourceFrom { get; set; }
        /// <summary>
        /// 销售名称
        /// </summary>
        public string ReferName { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 用户备注
        /// </summary>
        public string UserRemark { get; set; }
        /// <summary>
        /// 用户描述
        /// </summary>
        public string UserDescribe { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }
    }
}
