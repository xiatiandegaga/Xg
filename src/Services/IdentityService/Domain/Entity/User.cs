﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using Cloud.Domain.Entities;using Xg.Cloud.Core;

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Linq;
using Cloud.Utilities.Json;
using Identity.Shared;

namespace Domain.Entity
{
    /// <summary>
	/// 用户表
	/// </summary>
    public class User : BaseEntity<long>
    {
        public User()
        {
            this.Account = string.Empty;
            this.Password = string.Empty;
            this.Name = string.Empty;
            this.Mobile = string.Empty;
            this.Img = string.Empty;
            this.ThirdpartId = string.Empty;
            this.MachingCode = string.Empty;
            this.MemberCtgrId = 1;
            this.MemberPoint = 0;
            this.IsActivate = 0;
            this.IsVerifyPhone = 0;
            this.Status = 1;
            this.CreateDate = DateTime.Now;
            this.Sex = 0;
            this.SignInCount = 0;
            this.SignInDate = DateTime.Now;
            this.MemberLevel = 0;
            this.BirthDay = null;
            this.GiveBirthPoint = 0;
            this.PointRedeemNum = 0;
            this.WorkUnitCode = string.Empty;
            this.IsBlack = 0;
            this.UserPermissions = string.Empty;
            this.SourceFrom = IdentityCommonConst.SOURCEFROM_0;
            this.UserLabel = string.Empty;
            this.Address = string.Empty;
            this.Email = string.Empty;
        }


        /// <summary>
	    /// 账号
	    /// </summary>
        public string Account { get; set; }
        /// <summary>
	    /// 密码
	    /// </summary>
        public string Password { get; set; }
        /// <summary>
	    /// 姓名
	    /// </summary>
        public string Name { get; set; }
        /// <summary>
	    /// 联系电话
	    /// </summary>
        public string Mobile { get; set; }
        /// <summary>
	    /// 用户头像
	    /// </summary>
        public string Img { get; set; }
        /// <summary>
	    /// 第三方系统用户id（比如小程序的openid）
	    /// </summary>
        public string ThirdpartId { get; set; }
        /// <summary>
	    /// 机器码
	    /// </summary>
        public string MachingCode { get; set; }
        /// <summary>
	    /// 会员类型(1:个人会员卡)
	    /// </summary>
        public int MemberCtgrId { get; set; }
        /// <summary>
	    /// 会员积分
	    /// </summary>
        public int MemberPoint { get; set; }
        /// <summary>
	    /// 是否激活（1：已激活 0：未激活）消费满三次才激活
	    /// </summary>
        public int IsActivate { get; set; }
        /// <summary>
	    /// 是否验证手机（1：已验证 0：未验证）
	    /// </summary>
        public int IsVerifyPhone { get; set; }
        /// <summary>
	    /// 状态（1：正常 0：锁定）
	    /// </summary>
        public int Status { get; set; }
        /// <summary>
	    /// 创建日期
	    /// </summary>
        public System.DateTime CreateDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>

        public long CreateId { get; set; }
        /// <summary>
	    /// 性别 1为男 2为女 0未知
	    /// </summary>
        public int Sex { get; set; }
        /// <summary>
	    /// 签到次数
	    /// </summary>
        public int SignInCount { get; set; }
        /// <summary>
	    /// 签到日期
	    /// </summary>
        public System.DateTime? SignInDate { get; set; }
        /// <summary>
	    /// 会员等级
	    /// </summary>
        public int MemberLevel { get; set; }
        /// <summary>
	    /// 生日
	    /// </summary>
        public System.DateTime? BirthDay { get; set; }
        /// <summary>
	    /// 是否赠送过生日积分(0:未送 1：已送)
	    /// </summary>
        public int GiveBirthPoint { get; set; }
        /// <summary>
	    /// 积分兑换次数|云走廊值
	    /// </summary>
        public decimal PointRedeemNum { get; set; }
        /// <summary>
	    /// 工作单位code
	    /// </summary>
        public string WorkUnitCode { get; set; }
        /// <summary>
	    /// 是否拉黑1表示拉黑
	    /// </summary>
        public int IsBlack { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }


        /// <summary>
        /// 兴趣小组活动
        /// </summary>
        public string HobbyGroup { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// 部门id
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
        /// 是否赠送过入职日积分(0:未送 1：已送)
        /// </summary>
        public int GiveEntryPoint { get; set; }

        /// <summary>
        /// 客户渠道来源（ 0散客 1销售顾问集客  3转发 4海报分享 其他详见sys_cooperatorn表）
        /// </summary>
        public long SourceFrom { get; set; }
        /// <summary>
        /// 首次门店
        /// </summary>
        public long FirstFieldId { get; set; }
        /// <summary>
        /// 修改专属顾问时间
        /// </summary>
        public DateTime? UpdateSalesConsultantDate { get; set; }
        /// <summary>
        /// 线下连续签到次数
        /// </summary>
        public int SceneSignInCount { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public long FieldId { get; set; }
        /// <summary>
        /// 用户权限（按顺序 核销活动|核销订单|核销商城|可视化报表|小程序管理员|食堂管理员|仓库管理员|活动有礼核销|购房优惠券核销|盲盒订单核销|营销总|券商品核销权限 排列成如1010110，其中1表示有权限）
        /// </summary>
        public string UserPermissions { get; set; }
        /// <summary>
        /// 是否送过生日券（1表示送过）
        /// </summary>
        public int GiveBirthCoupon { get; set; }
        /// <summary>
        /// 盲盒连续签到次数
        /// </summary>
        public int BlindBboxCount { get; set; }
        /// <summary>
        /// 用户标签（按顺序 老业主  排列成如101011000，其中1表示是0表示否）
        /// </summary>
        public string UserLabel { get; set; }
        /// <summary>
        /// 海报类型（1 活动海报 2 通用模块 3 商品海报（包括秒杀商品）4 中海邀请入会  5南京万科邀请海报  6 中海长征海报）
        /// </summary>
        public string PostersType { get; set; }
        /// <summary>
        /// 海报主键
        /// </summary>
        public long PostersKey { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 商铺id
        /// </summary>
        public long XjShopId { get; set; }

        /// <summary>
        /// 绚集积分
        /// </summary>
        public int XjPoint { get; set; }
        /// <summary>
        /// 绚集盲盒连续抽奖次数
        /// </summary>
        public int XjBlindBboxCount { get; set; }
        /// <summary>
        /// 授权时间
        /// </summary>
        public DateTime? AuthDate { get; set; }
        /// <summary>
        /// 商铺id
        /// </summary>
        public long ShopId { get; set; }
        /// <summary>
        /// 快闪店id
        /// </summary>
        public long KsdShopId { get; set; }
        /// <summary>
        /// 用户在开放平台的唯一标识符，若当前小程序已绑定到微信开放平台帐号下会返回，详见 UnionID 机制说明
        /// </summary>
        public string Unionid { get; set; }
        /// <summary>
        /// 用户角色集合
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }

        /// <summary>
        /// 是否能核销活动 1表示可以核销
        /// </summary>
        public int IsCanVerifyActive()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions)) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[0].ToString());
            }
        }
        /// <summary>
        /// 是否能核销知味食光订单 1表示可以核销
        /// </summary>
        public int IsCanVerifyOrder()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 2) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[1].ToString());
            }
        }
        /// <summary>
        /// 是否能核销商城订单 1表示可以核销
        /// </summary>
        public int IsCanVerifyPointOrder()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 3) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[2].ToString());
            }
        }
        /// <summary>
        /// 是否有数据可视化权限
        /// </summary>
        public int IsReportView()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 4) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[3].ToString());
            }
        }
        /// <summary>
        /// 是否小程序管理员
        /// </summary>
        /// <returns></returns>
        public int IsAppletAdmin()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 5) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[4].ToString());
            }
        }
        /// <summary>
        /// 是否食堂管理员
        /// </summary>
        /// <returns></returns>
        public int IsCanteenAdmin()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 6) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[5].ToString());
            }
        }

        /// <summary>
        /// 是否仓库管理员
        /// </summary>
        /// <returns></returns>
        public int IsWarehouseKeeper()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 7) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[6].ToString());
            }
        }

        /// <summary>
        /// 是否活动有礼核销管理员
        /// </summary>
        /// <returns></returns>
        public int IsActivePresentAdmin()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 8) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[7].ToString());
            }
        }
        /// <summary>
        /// 是否能核销购房优惠券 1表示可以核销
        /// </summary>
        public int IsCanVerifyBuyHouseCoupon()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 9) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[8].ToString());
            }
        }
        /// <summary>
        /// 是否能核盲盒订单 1表示可以核销
        /// </summary>
        public int IsCanVerifyBlindBloxOrder()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 10) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[9].ToString());
            }
        }

        /// <summary>
        /// 营销总
        /// </summary>
        public int IsSaleManage()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 11) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[10].ToString());
            }
        }
        /// <summary>
        /// 券商品核销权限
        /// </summary>
        public int IsCanVerifyCouponProduct()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 12) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[11].ToString());
            }
        }
        /// <summary>
        /// 券商品核销权限
        /// </summary>
        public int IsCanVerifyEShopOrder()
        {
            if (string.IsNullOrWhiteSpace(this.UserPermissions) || this.UserPermissions.Length < 13) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserPermissions[12].ToString());
            }
        }
        /// <summary>
        /// 是否有聚合核销权限
        /// </summary>
        public bool IsCanVerify()
        {
            return this.IsCanVerifyActive() == 1 || this.IsCanVerifyBuyHouseCoupon() == 1 || this.IsActivePresentAdmin() == 1 || this.IsCanVerifyPointOrder() == 1 || this.IsCanVerifyOrder() == 1|| this.IsCanVerifyBlindBloxOrder() == 1||this.IsCanVerifyCouponProduct()==1 || this.IsCanVerifyEShopOrder() == 1;
        }
        /// <summary>
        /// 是否业主 1表示是
        /// </summary>
        public int IsOwner()
        {
            if (string.IsNullOrWhiteSpace(this.UserLabel)) { return 0; }
            else
            {
                return Convert.ToInt32(this.UserLabel[0].ToString());
            }
        }
        /// <summary>
        /// 设置用户对应角色
        /// </summary>
        /// <param name="roleIds"></param>
        public void SetRole(IEnumerable<long> roleIds)
        {
            if (roleIds == null)
                return;
            UserRoles = new Collection<UserRole>();
            foreach (long roleId in roleIds)
            {
                UserRoles.Add(new UserRole { RoleId = roleId });
            }
        }
    }
}