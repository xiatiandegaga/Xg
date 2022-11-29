﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using Cloud.Domain.Entities;using Xg.Cloud.Core;

using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain.Entity
{
    /// <summary>
	/// sys_role
	/// </summary>
    public class Role:BaseEntity<long>
    {
        public Role()
        {
          this.Name= string.Empty;
          this.Describe= string.Empty;
          this.Level= 0;
          this.CreateTime= DateTime.Now;
          this.UpdateTime= DateTime.Now;
          this.Status = 1;
        }


        /// <summary>
	    /// 角色名称
	    /// </summary>
        public string Name { get; set; }
        /// <summary>
	    /// 角色描述
	    /// </summary>
        public string Describe { get; set; }
        /// <summary>
	    /// 所属企业id
	    /// </summary>
       

        public long CompanyId { get; set; }
        /// <summary>
	    /// 角色分类id（系统角色、审批角色等）
	    /// </summary>
       

        public long CategoryId { get; set; }
        /// <summary>
	    /// 等级
	    /// </summary>
        public int Level { get; set; }
        /// <summary>
	    /// 创建时间
	    /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
	    /// 更新时间
	    /// </summary>
        public System.DateTime UpdateTime { get; set; }
        /// <summary>
	    /// 创建人
	    /// </summary>
       

        public long CreateUserId { get; set; }
        /// <summary>
	    /// 更新人
	    /// </summary>
       

        public long UpdateUserId { get; set; }
        /// <summary>
	    /// 状态（1：正常 0：删除）
	    /// </summary>
        public sbyte Status { get; set; }
        /// <summary>
        /// 共享数据的角色
        /// </summary>
        public string SharedDataRoleIds { get; set; }
        /// <summary>
        /// 用户角色集合
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}