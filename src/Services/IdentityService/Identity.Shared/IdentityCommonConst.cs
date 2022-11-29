using System.Collections.Generic;
using System.Data;

namespace Identity.Shared
{
    /// <summary>
    /// 公共常量
    /// </summary>
    public static class IdentityCommonConst
    {
        /// <summary>
        /// 获取流水号前缀
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public static string GetPrefix(string keyValue)
        {
            switch (keyValue)
            {
                //积分订单
                case "PointOrder":
                    return "PO";
                //积分流水
                case "PointFlow":
                    return "PF";
                //券
                case "Coupon":
                    return "CP";
                //券流水
                case "CouponFlow":
                    return "CF";
                //咖啡订单
                case "CoffeeOrder":
                    return "CO";
                //订单退款单
                case "RefundOrder":
                    return "RO";
                //积分发放
                case "ActiveOrder":
                    return "AO";
                //招商银行退款
                case "MerchanBankRefundOrder":
                    return "MBRO";
                //走廊值兑换积分
                case "CorridorValueOrder":
                    return "CVO";
                //积分发放
                case "PointIssueOrder":
                    return "PIO";
                //活动发放
                case "CompanyActive":
                    return "CA";
                //商品出库
                case "GoodsRel":
                    return "CR";
                //商品入库
                case "GoodsInv":
                    return "CI";
                //中奖商品
                case "LuckyDrawInfo":
                    return "LDI";
                //短信发送
                case "SendMsg":
                    return "SM";
                //红包节日
                case "HolidayRedEnvelope":
                    return "HRE";
                //工作流编号
                case "Workflow":
                    return "WF";
                //资产商品出库
                case "AssetGoodsRel":
                    return "AGR";
                //资产商品入库
                case "AssetGoodsInv":
                    return "AGI";
                //资产商品
                case "AssetGoods":
                    return "AG";
                //固定资产领用
                case "AssetFixedReceive":
                    return "LY";
                //固定资产归还
                case "AssetFixedReturn":
                    return "GH";
                //固定资产损耗
                case "AssetFixedLoss":
                    return "SH";
                //易耗品领用
                case "AssetLossReceive":
                    return "YHP";
                //盘点出入库
                case "AssetGoodsLoss":
                    return "PD";
                //补餐单据
                case "RepairMeal":
                    return "RM";
                //合作伙伴编号
                case "Cooperator":
                    return "COO";
                //购房优惠券核销订单编号
                case "CouponCheckOrder":
                    return "CCO";
                //盲盒流水编号
                case "BlindBboxFlow":
                    return "BBF";
                //电商订单编号
                case "ShopOrder":
                    return "ESO";

                //电商订单编号
                case "ShopOrderPayNo":
                    return "SOP";
                //发票编号
                case "InvoiceInfo":
                    return "IV";
                //盲盒活动订单编号
                case "BlindBboxActiveOrder":
                    return "BBAO";
                //盲盒活动流水编号
                case "BlindBboxActiveFlow":
                    return "BBAF";
                //盲盒活动流水编号
                case "PointRedeemNumFlow":
                    return "PRNF";

                //商品出库
                case "XjProductRel":
                    return "XJPR";
                //商品入库
                case "XjProductInv":
                    return "XJPI";
                case "XjLuckyDrawInfo":
                    return "XJLD";
                case "XjPointOrder":
                    return "XJPO";
                case "XjPointFlow":
                    return "XJPF";
                case "XjActiveOrder":
                    return "XJAO";
                case "XjLuckyDrawOpenCardInfo":
                    return "XJLD";
                case "XjBlindBboxFlow":
                    return "XJBF";
                case "XjCompanyActive":
                    return "XJCA";
                case "XjPointIssueOrder":
                    return "XJPIO";
                //砍一刀订单编号
                case "BargainOrder":
                    return "BO";
                case "Repair":
                    return "RP";
                case "LuckyDrawOpenCardInfo":
                    return "LD";
                case "LuckyDrawGoldenEggsInfo":
                    return "LD";
                case "DiscountCouponIssueDetail":
                    return "DC";
                case "DiscountCouponFlow":
                    return "DCF";
                case "FairActive":
                    return "FA";
                case "KsdProductRel":
                    return "KSDPR";
                case "KsdProductInv":
                    return "KSDPI";
                case "YsgActive":
                    return "YA";
                case "YsgActiveRel":
                    return "YAR";
                case "YsgActiveInv":
                    return "YAI";
                case "YsgActiveOrder":
                    return "YAO";
                    
                default: return "";

            }
        }

        #region 角色
        /// <summary>
        /// 系统管理员
        /// </summary>
        public const long ROLE_ADMIN = 1216563756688068648;
        /// <summary>
        /// 客户管理员
        /// </summary>
        public const long ROLE_CUSADMIN = 1216563756688068649;
        #endregion
        #region 性别类型
        /// <summary>
        /// 男
        /// </summary>
        public const int SEX_MAN = 1;
        /// <summary>
        /// 女
        /// </summary>
        public const int SEX_WOMAN = 2;
        /// <summary>
        /// 未知
        /// </summary>
        public const int SEX_UNKNOWN = 0;
        #endregion
        #region 工作流程编号
        /// <summary>
        /// 贺仪申报
        /// </summary>
        public const string WF_HEYI = "WF108971563532943360";
        /// <summary>
        /// 固定资产领用
        /// </summary>
        public const string WF_ASSETFIXEDRECEIVE = "WF108971762812715008";
        /// <summary>
        /// 固定资产归还
        /// </summary>
        public const string WF_ASSETFIXEDRETURN = "WF89668864773718019";
        /// <summary>
        /// 固定资产损耗
        /// </summary>
        public const string WF_ASSETFIXEDLOSS = "WF108971908539613184";
        /// <summary>
        /// 办公易耗品领用
        /// </summary>
        public const string WF_ASSETLOSSRECEIVE = "WF108971955167690752";

        /// <summary>
        /// 食堂易耗品领用
        /// </summary>
        public const string WF_DININGROOMASSETLOSSRECEIVE = "WF165043531541921792";
        /// <summary>
        /// 警用装备领用
        /// </summary>
        public const string WF_POILCEASSETFIXEDRECEIVE = "WF165043859398082560";
        /// <summary>
        /// 警用装备归还
        /// </summary>
        public const string WF_POLICEASSETFIXEDRETURN = "WF165044169705275392";
        /// <summary>
        /// 警用装备损耗
        /// </summary>
        public const string WF_POLICEASSETFIXEDLOSS = "WF165044083852066816";
        /// <summary>
        /// 其他类领用
        /// </summary>
        public const string WF_OTHERASSETFIXEDRECEIVE = "WF165046068466696192";
        /// <summary>
        /// 其他类归还
        /// </summary>
        public const string WF_OTHERASSETFIXEDRETURN = "WF165046007519264768";
        /// <summary>
        /// 其他类损耗
        /// </summary>
        public const string WF_OTHERASSETFIXEDLOSS = "WF165046121277177856";
        #endregion

        #region GlobalDataMaster
        /// <summary>
        /// 积分规则类型
        /// </summary>
        public const string POINTRULE = "PointRule";

        /// <summary>
        /// 退款原因
        /// </summary>
        public const string REFUNDREASON = "RefundReason";
        /// <summary>
        /// 错误提示
        /// </summary>
        public const string ERRMSG = "ErrMsg";
        /// <summary>
        /// 主订单状态
        /// </summary>
        public const string ORDERSTATUS = "OrderStatus";
        /// <summary>
        /// 订单明细状态
        /// </summary>
        public const string ORDERITEMSTATUS = "OrderItemStatus";
        /// <summary>
        /// 积分类型
        /// </summary>
        public const string POINTORDER = "PointOrder";

        /// <summary>
        /// 券类型
        /// </summary>
        public const string COUPONTYPE = "CouponType";
        /// <summary>
        /// 自动服务名称
        /// </summary>
        public const string AUTOSERVICEINTERVAL = "AutoServiceInterval";
        /// <summary>
        /// 公司信息
        /// </summary>
        public const string CUSTOMERUNIT = "CustomerUnit";
        /// <summary>
        /// 折扣活动
        /// </summary>
        public const string ACTIVECODE = "ActiveCode";
        /// <summary>
        /// 招行支付公钥
        /// </summary>
        public const string MERCHANTSBANKPUBKEY = "MerchantsBankPubKey";

        /// <summary>
        /// 折扣类型
        /// </summary>
        public const string DISCOUNTVALUETYPE = "DisCountValueType";
        /// <summary>
        /// 无敌券有效期
        /// </summary>
        public const string INVINCIBLECOUPON = "InvincibleCoupon";
        /// <summary>
        /// 折扣券有效期
        /// </summary>
        public const string DISCOUNTCOUPON = "DiscountCoupon";
        /// <summary>
        /// 贺仪类别
        /// </summary>
        public const string CONGRATSCLASS = "CongratsClass";
        /// <summary>
        /// 活动类型
        /// </summary>
        public const string HOBBYGROUP = "HobbyGroup";

        /// <summary>
        /// 积分发放
        /// </summary>
        public const string POINTISSUE = "PointIssue";
        /// <summary>
        /// 红包节日
        /// </summary>
        public const string HOLIDAYTYPE = "HolidayType";
        /// <summary>
        /// 展示类型
        /// </summary>
        public const string SHOWTYPE = "ShowType";
        /// <summary>
        /// 单位类型
        /// </summary>
        public const string UNITTYPE = "UnitType";
        /// <summary>
        /// 短信模板
        /// </summary>
        public const string SENDMSG = "SendMsg";

        /// <summary>
        /// 短信签名
        /// </summary>
        public const string SENDMSGSIGN = "SendMsgSign";
        /// <summary>
        /// 商城订单状态
        /// </summary>
        public const string POINTORDERSTATUS = "PointOrderStatus";
        /// <summary>
        /// 咖啡机器厂商
        /// </summary>
        public const string MACHINEMANUFACTURER = "MachineManufacturer";
        /// <summary>
        /// 距离等级
        /// </summary>
        public const string DISTANCELEVEL = "DistanceLevel";
        /// <summary>
        /// 商品类型
        /// </summary>
        public const string GOODSTYPE = "GoodsType";

        /// <summary>
        /// 系统使用范围
        /// </summary>
        public const string USINGRANGETYPE = "UsingRangeType";
        /// <summary>
        /// 咖啡订单支付模式
        /// </summary>
        public const string COFFEEPAYWAY = "CoffeePayWay";
        /// <summary>
        /// 商城订单支付模式
        /// </summary>
        public const string POINTGOODSPAYWAY = "PointGoodsPayWay";
        /// <summary>
        /// 通用列表模块
        /// </summary>
        public const string COMMONMODULE = "CommonModule";
        /// <summary>
        /// 机构类型
        /// </summary>
        public const string DEPTTYPE = "DeptType";
        /// <summary>
        /// 职位类型
        /// </summary>
        public const string POSITIONTYPE = "PositionType";
        /// <summary>
        /// 部门分类
        /// </summary>
        public const string DEPTCLASSTYPE = "DeptClassType";
        /// <summary>
        /// 定量考评类型
        /// </summary>
        public const string KPITYPE = "KPIType";
        /// <summary>
        /// 定性考评类型
        /// </summary>
        public const string QUALITATIVECLASSTYPE = "QualitativeClassType";
        /// <summary>
        /// 考评批次号
        /// </summary>
        public const string APPRAISALBATCHNO = "AppraisalBatchNo";
        /// <summary>
        /// 关联部门类型
        /// </summary>
        public const string REFDEPTTYPE = "RefDeptType";
        /// <summary>
        /// 车辆预约状态
        /// </summary>
        public const string MAKEAPPOINTMENTSTATUS = "MakeAppointmentStatus";
        /// <summary>
        /// 流程状态
        /// </summary>
        public const string FLOWSTATUS = "FlowStatus";
        /// <summary>
        /// 流程记录状态
        /// </summary>
        public const string FLOWRECORDSTATUS = "FlowRecordStatus";
        /// <summary>
        /// 收藏类型
        /// </summary>
        public const string COLLECTIONTYPE = "CollectionType";
        /// <summary>
        /// 资产商品类型
        /// </summary>
        public const string ASSETGOODSTYPE = "AssetGoodsType";
        /// <summary>
        /// 资产商品入库类型
        /// </summary>
        public const string ASSETGOODSINVTYPE = "AssetGoodsInvType";
        /// <summary>
        /// 资产商品出库类型
        /// </summary>
        public const string ASSETGOODSRELTYPE = "AssetGoodsRelType";
        /// <summary>
        /// 资产申请状态
        /// </summary>
        public const string ASSETAPPROVESTATUS = "AssetApproveStatus";
        /// <summary>
        /// 抽奖商品类型
        /// </summary>
        public const string LUCKYDRAWACTIVEGOODSTYPE = "LuckyDrawActiveGoodsType";
        /// <summary>
        /// 抽奖模式
        /// </summary>
        public const string LUCKYACTIVETYPE = "LuckyActiveType";
        /// <summary>
        /// 抽奖频率
        /// </summary>
        public const string LUCKYDRAWFREQUENCY = "LuckyDrawFrequency";
        /// <summary>
        /// 翻牌抽奖模式
        /// </summary>
        public const string LUCKYOPENCARDACTIVETYPE = "LuckyOpenCardActiveType";
        /// <summary>
        /// 标签认证类型
        /// </summary>
        public const string USERLABELTYPE = "UserLabelType";
        /// <summary>
        /// 标签条件类型
        /// </summary>
        public const string LABELCONDITIONTYPE = "LabelConditionType";
        /// <summary>
        /// 问题类型
        /// </summary>
        public const string QUESTIONTYPE = "QuestionType";
        /// <summary>
        /// 领用状态
        /// </summary>
        public const string ASSETRECEIVESTATUS = "AssetReceiveStatus";
        /// <summary>
        /// 预约服务类型
        /// </summary>
        public const string MAKEAPPOINTMENTTYPE = "MakeAppointmentType";

        /// <summary>
        /// 周期类型
        /// </summary>
        public const string CYCLETYPE = "CycleType";

        /// <summary>
        /// 菜品分类
        /// </summary>
        public const string GOODSCLASS = "GoodsClass";

        /// <summary>
        /// 链接类型
        /// </summary>
        public const string LINKTYPE = "LinkType";

        /// <summary>
        /// 租赁类型
        /// </summary>
        public const string CONSULTETYPE = "ConsulteType";
        /// <summary>
        /// 盲盒抽奖物品类型
        /// </summary>
        public const string BLINDBBOXGOODSTYPE = "BlindBboxGoodsType";
        /// <summary>
        /// 学历类型
        /// </summary>
        public const string EDUCATIONTYPE = "EducationType";
        /// <summary>
        /// 政治面貌类型
        /// </summary>
        public const string POLITICSSTATUSTYPE = "PoliticsStatusType";


        /// <summary>
        /// 物流类型
        /// </summary>
        public const string LOGISTICSTYPE = "LogisticsType";
        /// <summary>
        /// 收货类型
        /// </summary>
        public const string TAKEGOODSTYPE = "TakeGoodsType";
        /// <summary>
        /// 电商订单状态
        /// </summary>
        public const string ESHOPORDERSTATUS = "EShopOrderStatus";
        /// <summary>
        /// 电商订单售后状态
        /// </summary>
        public const string ESHOPORDERAFTERSTATUS = "EShopOrderAfterStatus";
        /// <summary>
        /// 支付方式
        /// </summary>
        public const string PAYCHANNEL = "PayChannel";

        /// <summary>
        /// 抬头类型
        /// </summary>
        public const string INVOICEOBJECTTYPE = "InvoiceObjectType";
        /// <summary>
        /// 发票类型
        /// </summary>
        public const string INVOICETYPE = "InvoiceType";

        /// <summary>
        /// 开票状态
        /// </summary>
        public const string INVOICESTATUS = "InvoiceStatus";

        /// <summary>
        /// 海报类型
        /// </summary>
        public const string POSTERSTYPE = "PostersType";

        /// <summary>
        /// 活动方式
        /// </summary>
        public const string ACTIVEPARTINWAYTYPE = "ActivePartInWayType";

        /// <summary>
        /// 长征展示线路方式
        /// </summary>
        public const string SHOWROUTEWAY = "ShowRouteWay";

        /// <summary>
        /// 券有效期类型
        /// </summary>
        public const string EFFECTTYPE = "EffectType";


        /// <summary>
        /// 核销方式
        /// </summary>
        public const string CHECKWAY = "CheckWay";

        /// <summary>
        /// 反馈类型
        /// </summary>
        public const string FEEDBACKTYPE = "FeedBackType";
        /// <summary>
        /// 盲盒活动类型
        /// </summary>
        public const string BLINDBBOXACTIVETYPE = "BlindBboxActiveType";

        /// <summary>
        /// 盲盒活动订单状态
        /// </summary>
        public const string BLINDBBOXACTIVEORDERSTATUS = "BlindBboxActiveOrderStatus";

        /// <summary>
        /// 邀约类型
        /// </summary>
        public const string INVITATETYPE = "InvitateType";

        /// <summary>
        /// 用户标签
        /// </summary>
        public const string USERLABELCODE = "UserLabelCode";

        /// <summary>
        /// Call客状态
        /// </summary>
        public const string CALLSTATUS = "CallStatus";


        /// <summary>
        /// 绚集订单积分类型
        /// </summary>
        public const string XJPOINTORDER = "XjPointOrder";

        /// <summary>
        /// 绚集抽奖商品类型
        /// </summary>
        public const string XJLUCKYDRAWACTIVEGOODSTYPE = "XjLuckyDrawActiveGoodsType";

        /// <summary>
        /// 绚集抽奖商品类型
        /// </summary>
        public const string XJBLINDBBOXGOODSTYPE = "XjBlindBboxGoodsType";

        /// <summary>
        /// 绚集积分发放
        /// </summary>
        public const string XJPOINTISSUE = "XjPointIssue";

        /// <summary>
        /// call客用户来源
        /// </summary>
        public const string CALLKESOURCEFROM = "CallKeSourceFrom";

        /// <summary>
        /// 维修状态
        /// </summary>
        public const string REPAIRSTATUS = "RepairStatus";
        /// <summary>
        /// 维修物品
        /// </summary>
        public const string REPAIRGOODSTYPE = "RepairGoodsType";
        /// <summary>
        /// 核销二维码type
        /// </summary>
        public const string VERIFICATECODETYPE = "VerificateCodeType";
        /// <summary>
        /// 海报二维码type
        /// </summary>
        public const string POSTERCODETYPE = "PosterCodeType";
        /// <summary>
        /// 短视频状态
        /// </summary>
        public const string VIDEOINFOSTATUS = "VideoInfoStatus";
        /// <summary>
        /// 折扣券类型
        /// </summary>
        public const string DISCOUNTCOUPONTYPE = "DiscountCouponType";


        /// <summary>
        /// 预约时间段
        /// </summary>
        public const string MARKTIMETYPE = "MarkTimeType";

        /// <summary>
        /// 卡密分配方式
        /// </summary>
        public const string PRODUCTCARDPASSWORDALLOTTYPE = "ProductCardPasswordAllotType";


        /// <summary>
        /// 短视频类型
        /// </summary>
        public const string VIDEOSHOWTYPE = "VideoShowType";

        /// <summary>
        /// 通用商铺类型
        /// </summary>
        public const string SZSHOPTYPE = "SzShopType";

        /// <summary>
        /// 艺术馆活动类型
        /// </summary>
        public const string YSGACTIVETYPE = "YsgActiveType";
        /// <summary>
        /// 私宴预约活动时间
        /// </summary>
        public const string MARKTIMEFORCHECKTYPE = "MarkTimeForCheckType";
        #endregion
        #region GlobalData
        #region 机构类型
        /// <summary>
        /// 总公司
        /// </summary>
        public const string ORGTYPE_HEADOFFICE = "1";
        /// <summary>
        /// 分公司
        /// </summary>
        public const string ORGTYPE_BRANCHOFFICE = "2";
        /// <summary>
        /// 支公司
        /// </summary>
        public const string ORGTYPE_SUBSIDIARYCOMPANY = "3";
        /// <summary>
        /// 部门
        /// </summary>
        public const string ORGTYPE_DEPARTMENT = "4";
        /// <summary>
        /// 处室
        /// </summary>
        public const string ORGTYPE_OFFICE = "5";
        /// <summary>
        /// 岗位
        /// </summary>
        public const string ORGTYPE_POST = "6";
        /// <summary>
        /// 其他
        /// </summary>
        public const string ORGTYPE_OTHER = "7";
        #endregion
        #region 职位类型
        /// <summary>
        /// 总经理
        /// </summary>
        public const string POSITIONTYPE_GENERALMANAGER = "1";
        /// <summary>
        /// PIC
        /// </summary>
        public const string POSITIONTYPE_PIC = "2";
        /// <summary>
        /// 部门总
        /// </summary>
        public const string POSITIONTYPE_DEPARTMENTMANAGER = "3";
        /// <summary>
        /// 主管
        /// </summary>
        public const string POSITIONTYPE_DIRECTOR = "4";
        /// <summary>
        /// 员工
        /// </summary>
        public const string POSITIONTYPE_EMPLOYEE = "5";

        /// <summary>
        /// 销售总监
        /// </summary>
        public const string POSITIONTYPE_XIAOSHOUZONGJIAN = "XiaoShouZongJian";

        /// <summary>
        /// 销售总经理
        /// </summary>
        public const string POSITIONTYPE_XIAOSHOUZONGJINGLI = "XiaoShouZongJingLi";

        /// <summary>
        /// 销售经理
        /// </summary>
        public const string POSITIONTYPE_XIAOSHOUJINGLI = "XiaoShouJingLi";

        /// <summary>
        /// 销售
        /// </summary>
        public const string POSITIONTYPE_XIAOSHOU = "XiaoShou";
        #endregion
        #region 部门分类
        /// <summary>
        /// 前台
        /// </summary>
        public const string DEPTCLASSTYPE_FRONTDESK = "1";
        /// <summary>
        /// 中台
        /// </summary>
        public const string DEPTCLASSTYPE_MIDDLEDESK = "2";
        /// <summary>
        /// 后台
        /// </summary>
        public const string DEPTCLASSTYPE_BACKDESK = "3";
        #endregion
        #region KPI类型
        /// <summary>
        /// 业务指标
        /// </summary>
        public const string KPITYPE_BUSINESSINDICATORS = "1";
        /// <summary>
        /// 重点工作
        /// </summary>
        public const string KPITYPE_KEYWORK = "2";
        #endregion
        #region 定性考评类型
        /// <summary>
        /// 品德操守
        /// </summary>
        public const string QUALITATIVECLASSTYPE_MORALITY = "1";
        /// <summary>
        /// 能力态度
        /// </summary>
        public const string QUALITATIVECLASSTYPE_ABILITYATTITUDE = "2";
        /// <summary>
        /// 质量效率
        /// </summary>
        public const string QUALITATIVECLASSTYPE_EFFICIENCYQUALITY = "3";
        /// <summary>
        /// 沟通协作
        /// </summary>
        public const string QUALITATIVECLASSTYPE_COMMUNECOLLABORATE = "4";
        #endregion
        #region 预约服务类型（MakeAppointmentType）
        /// <summary>
        /// 车辆出险
        /// </summary>
        public const string MAKEAPPOINTMENTTYPE_CARACCIDENT = "CarAccident";
        /// <summary>
        /// 维修保养
        /// </summary>
        public const string MAKEAPPOINTMENTTYPE_CARMAINTENANCE = "CarMaintenance";
        /// <summary>
        /// 车险续保
        /// </summary>
        public const string MAKEAPPOINTMENTTYPE_CARINSURANCERENEWAL = "CarInsuranceRenewal";
        #endregion
        #region 车辆预约状态（MakeAppointmentStatus）
        /// <summary>
        /// 待开始
        /// </summary>
        public const string MAKEAPPOINTMENTSTATUS_1 = "1";
        /// <summary>
        /// 已取消
        /// </summary>
        public const string MAKEAPPOINTMENTSTATUS_2 = "2";
        /// <summary>
        /// 已完成
        /// </summary>
        public const string MAKEAPPOINTMENTSTATUS_3 = "3";
        #endregion
        #region 流程状态
        /// <summary>
        /// 删除
        /// </summary>
        public const string FLOWSTATUS_0 = "0";
        /// <summary>
        /// 草稿
        /// </summary>
        public const string FLOWSTATUS_1 = "1";
        /// <summary>
        /// 审核中
        /// </summary>
        public const string FLOWSTATUS_2 = "2";
        /// <summary>
        /// 通过
        /// </summary>
        public const string FLOWSTATUS_3 = "3";
        /// <summary>
        /// 驳回
        /// </summary>
        public const string FLOWSTATUS_4 = "4";
        /// <summary>
        /// 取消
        /// </summary>
        public const string FLOWSTATUS_7 = "7";
        #endregion
        #region 流程记录状态

        /// <summary>
        /// 未审核
        /// </summary>
        public const string FLOWRECORDSTATUS_0 = "0";
        /// <summary>
        /// 通过
        /// </summary>
        public const string FLOWRECORDSTATUS_1 = "1";
        /// <summary>
        /// 驳回
        /// </summary>
        public const string FLOWRECORDSTATUS_2 = "2";
        #endregion
        #region 积分规则类型
        /// <summary>
        /// 签到
        /// </summary>
        public const string POINTRULE_SIGNIN = "SignIn";
        /// <summary>
        /// 首次注册送积分
        /// </summary>
        public const string POINTRULE_FIRSTREGIST = "FirstRegist";
        /// <summary>
        /// 完善信息送积分
        /// </summary>
        public const string POINTRULE_FINISHUSERINFO = "FinishUserInfo";
        /// <summary>
        /// 生日送积分规则（自动服务）
        /// </summary>
        public const string POINTRULE_GIVEPOINTSONBIRTHDAY = "GivePointsOnBirthday";
        /// <summary>
        /// 3月8号送积分规则（自动服务）
        /// </summary>
        public const string POINTRULE_GIVEPOINTSON38 = "GivePointsOn38";
        /// <summary>
        /// 通用公式规则（自动服务）
        /// </summary>
        public const string POINTRULE_GENERALRULE = "GeneralRule";
        /// <summary>
        /// 现金支付获取积分
        /// </summary>
        public const string POINTRULE_POINTPAYRULES = "PointPayRules";
        /// <summary>
        /// 活跃度奖励积分
        /// </summary>
        public const string POINTRULE_MONTHTASKPRESENT = "MonthTaskPresent";
        /// <summary>
        /// 走廊值兑换
        /// </summary>
        public const string POINTRULE_CORRIDORVALUEEXCHANGEPOINT = "CorridorValueExchangePoint";
        /// <summary>
        /// 入职送积分规则（自动服务）
        /// </summary>
        public const string POINTRULE_GIVEPOINTSONENTRYDAY = "GivePointsOnEntryday";
        /// <summary>
        /// 绑定员工送积分
        /// </summary>
        public const string POINTRULE_BINDEMPLOYEE = "BindEmployee";
        /// <summary>
        /// 线下签到送积分
        /// </summary>
        public const string POINTRULE_SCENESIGNIN = "SceneSignIn";
        /// <summary>
        /// 活动抽奖
        /// </summary>
        public const string POINTRULE_LUCKYDRAWACTIVEGOODS = "LuckyDrawActiveGoods";
        /// <summary>
        /// 生日到店送积分
        /// </summary>
        public const string POINTRULE_BIRTHDAYCOMEPOINT = "BirthDayComePoint";
        /// <summary>
        /// 预约有礼送积分
        /// </summary>
        public const string POINTRULE_CARMAINTENANCEPOINT = "CarMaintenancePoint";
        /// <summary>
        /// 续保有礼送积分
        /// </summary>
        public const string POINTRULE_CARINSURANCERENEWALPOINT = "CarInsuranceRenewalPoint";
        /// <summary>
        /// 盲盒抽奖
        /// </summary>
        public const string POINTRULE_BLINDBBOXPOINT = "BlindBboxPoint";
        /// <summary>
        /// 文章阅读
        /// </summary>
        public const string POINTRULE_READARTICLEPOINT = "ReadArticlePoint";
        /// <summary>
        /// 老带新
        /// </summary>
        public const string POINTRULE_PULLNEW = "PullNew";

        /// <summary>
        /// 老业主送积分
        /// </summary>
        public const string POINTRULE_OWNERGIVEPOINT = "OwnerGivePoint";
        /// <summary>
        /// 问卷调查送积分
        /// </summary>
        public const string POINTRULE_QUESTION = "Question";
        /// <summary>
        /// 盲盒活动抽奖
        /// </summary>
        public const string POINTRULE_BLINDBBOXACTIVE = "BlindBboxActive";

        /// <summary>
        /// 编制员工送积分
        /// </summary>
        public const string POINTRULE_ESTABLISHEDEMPLOYEE = "EstablishedEmployee";

        /// <summary>
        /// 认购送积分
        /// </summary>
        public const string POINTRULE_OFFERTOBUY = "OfferToBuy";

        /// <summary>
        /// 认证企业员工送积分
        /// </summary>
        public const string POINTRULE_COMPANYEMPLOYEE = "CompanyEmployee";
        /// <summary>
        /// 绚集活动抽奖
        /// </summary>
        public const string POINTRULE_XJLUCKYDRAWACTIVEGOODS = "XjLuckyDrawActiveGoods";

        /// <summary>
        /// 绚集翻牌活动
        /// </summary>
        public const string POINTRULE_XJLUCKYDRAWOPENCARDACTIVEGOODS = "XjLuckyDrawOpenCardActiveGoods";

        /// <summary>
        /// 绚集盲盒抽奖
        /// </summary>
        public const string POINTRULE_XJBLINDBBOXPOINT = "XjBlindBboxPoint";

        /// <summary>
        /// 翻牌活动
        /// </summary>
        public const string POINTRULE_LUCKYDRAWOPENCARDACTIVEGOODS = "LuckyDrawOpenCardActiveGoods";

        /// <summary>
        /// 砸金蛋活动
        /// </summary>
        public const string POINTRULE_LUCKYDRAWGOLDENEGGSACTIVEGOODS = "LuckyDrawGoldenEggsActiveGoods";

        /// <summary>
        /// 投骰子活动
        /// </summary>
        public const string POINTRULE_LUCKYDRAWDICEACTIVEGOODS = "LuckyDrawDiceActiveGoods";

        /// <summary>
        /// 上海金地嘉源Vip认证
        /// </summary>
        public const string POINTRULE_VIPRENZHENG = "VipRenZheng";



        /// <summary>
        /// 小票送积分
        /// </summary>
        public const string POINTRULE_TICKETGIVEPOINT = "TicketGivePoint";

        /// <summary>
        /// 标签认证送积分
        /// </summary>
        public const string POINTRULE_USERLABELAUTH = "UserLabelAuth";

        /// <summary>
        /// 完善地址送积分
        /// </summary>
        public const string POINTRULE_FINISHADDRESS = "FinishAddress";

        /// <summary>
        /// 嘉兴万科会员卡认证
        /// </summary>
        public const string POINTRULE_JIAXINHUIYUANRENZHENG = "jiaXinHuiYuanRenZheng";

        #endregion
        #region 资产入库类型
        /// <summary>
        /// 库存入库
        /// </summary>
        public const string ASSETGOODSINVTYPE_1 = "1";
        /// <summary>
        /// 归还入库
        /// </summary>
        public const string ASSETGOODSINVTYPE_2 = "2";
        /// <summary>
        /// 盘点入库
        /// </summary>
        public const string ASSETGOODSINVTYPE_3 = "3";
        /// <summary>
        /// 调拨入库
        /// </summary>
        public const string ASSETGOODSINVTYPE_4 = "4";
        #endregion
        #region 资产出库类型
        /// <summary>
        /// 库存出库
        /// </summary>
        public const string ASSETGOODSRELTYPE_1 = "1";
        /// <summary>
        /// 领用出库
        /// </summary>
        public const string ASSETGOODSRELTYPE_2 = "2";
        /// <summary>
        /// 盘点出库
        /// </summary>
        public const string ASSETGOODSRELTYPE_3 = "3";
        /// <summary>
        /// 调拨出库
        /// </summary>
        public const string ASSETGOODSRELTYPE_4 = "4";
        /// <summary>
        /// 耗损出库
        /// </summary>
        public const string ASSETGOODSRELTYPE_5 = "5";
        #endregion
        #region 资产领用状态
        /// <summary>
        /// 已删除
        /// </summary>
        public const string AssetApproveStatus_0 = "0";
        /// <summary>
        /// 草稿
        /// </summary>
        public const string AssetApproveStatus_1 = "1";
        /// <summary>
        /// 审核中
        /// </summary>
        public const string AssetApproveStatus_2 = "2";
        /// <summary>
        /// 通过
        /// </summary>
        public const string AssetApproveStatus_3 = "3";
        /// <summary>
        /// 驳回
        /// </summary>
        public const string AssetApproveStatus_4 = "4";
        /// <summary>
        /// 部分归还
        /// </summary>
        public const string AssetApproveStatus_5 = "5";
        /// <summary>
        /// 已归还
        /// </summary>
        public const string AssetApproveStatus_6 = "6";
        /// <summary>
        /// 已取消
        /// </summary>
        public const string AssetApproveStatus_7 = "7";
        #endregion
        #region 活动抽奖商品类型
        /// <summary>
        /// 积分
        /// </summary>
        public const string LUCKYDRAWACTIVEGOODSTYPE_1 = "1";
        /// <summary>
        /// 咖啡券
        /// </summary>
        public const string LUCKYDRAWACTIVEGOODSTYPE_2 = "2";
        /// <summary>
        /// 商品
        /// </summary>
        public const string LUCKYDRAWACTIVEGOODSTYPE_3 = "3";
        /// <summary>
        /// 谢谢惠顾
        /// </summary>
        public const string LUCKYDRAWACTIVEGOODSTYPE_4 = "4";
        #endregion
        #region 活动抽奖模式
        /// <summary>
        /// 普通模式
        /// </summary>
        public const string LUCKYACTIVETYPE_1 = "1";
        /// <summary>
        /// 助力模式
        /// </summary>
        public const string LUCKYACTIVETYPE_2 = "2";
        /// <summary>
        /// 刷新模式
        /// </summary>
        public const string LUCKYACTIVETYPE_3 = "3";

        #endregion
        #region 活动抽奖频率
        /// <summary>
        /// 只能抽一次
        /// </summary>
        public const string LUCKYDRAWFREQUENCY_1 = "1";
        /// <summary>
        /// 每天抽一次
        /// </summary>
        public const string LUCKYDRAWFREQUENCY_2 = "2";

        #endregion
        #region 翻牌活动抽奖模式

        /// <summary>
        /// 助力模式
        /// </summary>
        public const string LUCKYOPENCARDACTIVETYPE_2 = "2";
        /// <summary>
        /// 积分模式
        /// </summary>
        public const string LUCKYOPENCARDACTIVETYPE_4 = "4";

        #endregion
        #region 砸金蛋活动抽奖模式

        /// <summary>
        /// 助力模式
        /// </summary>
        public const string LUCKYGOLDENEGGSACTIVETYPE_2 = "2";
        /// <summary>
        /// 积分模式
        /// </summary>
        public const string LUCKYGOLDENEGGSACTIVETYPE_4 = "4";

        #endregion
        #region 掷骰子活动抽奖模式

        /// <summary>
        /// 助力模式
        /// </summary>
        public const string LUCKYDICEACTIVETYPE_2 = "2";
        /// <summary>
        /// 积分模式
        /// </summary>
        public const string LUCKYDICEACTIVETYPE_4 = "4";

        #endregion
        #region 标签认证类型
        /// <summary>
        /// 客户申请认证
        /// </summary>
        public const string USERLABELTYPE_1 = "1";
        /// <summary>
        /// 自动服务认证
        /// </summary>
        public const string USERLABELTYPE_2 = "2";

        /// <summary>
        /// 后台直接认证
        /// </summary>
        public const string USERLABELTYPE_3 = "3";
        /// <summary>
        /// 客户自动认证
        /// </summary>
        public const string USERLABELTYPE_4 = "4";

        #endregion
        #region 标签条件类型
        /// <summary>
        /// 线上签到次数
        /// </summary>
        public const string LABELCONDITIONTYPE_1 = "1";
        /// <summary>
        /// 线下签到次数
        /// </summary>
        public const string LABELCONDITIONTYPE_2 = "2";
        /// <summary>
        /// 活动报名次数
        /// </summary>
        public const string LABELCONDITIONTYPE_3 = "3";
        /// <summary>
        /// 活动核销次数
        /// </summary>
        public const string LABELCONDITIONTYPE_4 = "4";
        /// <summary>
        /// 饮品兑换次数
        /// </summary>
        public const string LABELCONDITIONTYPE_5 = "5";
        /// <summary>
        /// 商城兑换次数
        /// </summary>
        public const string LABELCONDITIONTYPE_6 = "6";
        #endregion
        #region 周期类型
        /// <summary>
        /// 只能一次
        /// </summary>
        public const string CYCLETYPE_1 = "1";
        /// <summary>
        /// 每天一次
        /// </summary>
        public const string CYCLETYPE_2 = "2";
        #endregion
        #region 菜品分类
        /// <summary>
        /// 全荤
        /// </summary>
        public const string GOODSCLASS_1 = "1";
        /// <summary>
        /// 大荤
        /// </summary>
        public const string GOODSCLASS_2 = "2";
        /// <summary>
        /// 小荤
        /// </summary>
        public const string GOODSCLASS_3 = "3";
        /// <summary>
        /// 素菜
        /// </summary>
        public const string GOODSCLASS_4 = "4";
        #endregion
        #region 链接类型
        /// <summary>
        /// 多图
        /// </summary>
        public const string LINKTYPE_1 = "1";
        /// <summary>
        /// 小程序
        /// </summary>
        public const string LINKTYPE_2 = "2";
        /// <summary>
        /// 公众号
        /// </summary>
        public const string LINKTYPE_3 = "3";
        /// <summary>
        /// 商品
        /// </summary>
        public const string LINKTYPE_4 = "4";
        /// <summary>
        /// 活动
        /// </summary>
        public const string LINKTYPE_5 = "5";
        /// <summary>
        /// 自定义页面
        /// </summary>
        public const string LINKTYPE_6 = "6";
        /// <summary>
        /// 视频
        /// </summary>
        public const string LINKTYPE_7 = "7";
        #endregion
        #region 租赁类型
        /// <summary>
        /// 租赁咨询
        /// </summary>
        public const string CONSULTETYPE_1 = "1";
        /// <summary>
        /// 故障维修
        /// </summary>
        public const string CONSULTETYPE_2 = "2";
        /// <summary>
        /// 试喝申请
        /// </summary>
        public const string CONSULTETYPE_3 = "3";
        #endregion
        #region 盲盒抽奖物品类型
        /// <summary>
        /// 积分
        /// </summary>
        public const string BLINDBBOXGOODSTYPE_1 = "1";
        /// <summary>
        /// 商品
        /// </summary>
        public const string BLINDBBOXGOODSTYPE_2 = "2";
        /// <summary>
        /// 折扣券
        /// </summary>
        public const string BLINDBBOXGOODSTYPE_3 = "3";
        /// <summary>
        /// 火力值
        /// </summary>
        public const string BLINDBBOXGOODSTYPE_4 = "4";
        #endregion
        #region 资产商品类型
        /// <summary>
        /// 固定资产
        /// </summary>
        public const string ASSETGOODSTYPE_1 = "1";
        /// <summary>
        /// 办公易耗品
        /// </summary>
        public const string ASSETGOODSTYPE_2 = "2";
        /// <summary>
        /// 警用装备
        /// </summary>
        public const string ASSETGOODSTYPE_3 = "3";
        /// <summary>
        /// 食堂易耗品
        /// </summary>
        public const string ASSETGOODSTYPE_4 = "4";
        /// <summary>
        /// 其他类需归还
        /// </summary>
        public const string ASSETGOODSTYPE_5 = "5";
        #endregion

        #region 物流类型
        /// <summary>
        /// 顺丰快递
        /// </summary>
        public const string LOGISTICSTYPE_1 = "1";
        #endregion
        #region 收货类型
        /// <summary>
        /// 商家配送
        /// </summary>
        public const string TAKEGOODSTYPE_1 = "1";
        /// <summary>
        /// 到店自提
        /// </summary>
        public const string TAKEGOODSTYPE_2 = "2";
        #endregion
        #region 电商订单状态
        /// <summary>
        /// 待付款
        /// </summary>
        public const string ESHOPORDERSTATUS_0 = "0";
        /// <summary>
        /// 待发货
        /// </summary>
        public const string ESHOPORDERSTATUS_1 = "1";
        /// <summary>
        /// 待收货
        /// </summary>
        public const string ESHOPORDERSTATUS_2 = "2";
        /// <summary>
        /// 已完成
        /// </summary>
        public const string ESHOPORDERSTATUS_3 = "3";
        /// <summary>
        /// 退款中
        /// </summary>
        public const string ESHOPORDERSTATUS_4 = "4";
        /// <summary>
        /// 已退款
        /// </summary>
        public const string ESHOPORDERSTATUS_5 = "5";
        /// <summary>
        /// 已取消
        /// </summary>
        public const string ESHOPORDERSTATUS_F1 = "-1";
        /// <summary>
        /// 退货申请
        /// </summary>
        public const string ESHOPORDERSTATUS_F2 = "-2";
        /// <summary>
        /// 退货中
        /// </summary>
        public const string ESHOPORDERSTATUS_F3 = "-3";
        /// <summary>
        /// 已退货
        /// </summary>
        public const string ESHOPORDERSTATUS_F4 = "-4";


        #endregion
        #region 电商订单售后状态
        /// <summary>
        /// 未售后
        /// </summary>
        public const string ESHOPORDERAFTERSTATUS_0 = "0";
        /// <summary>
        /// 申请售后
        /// </summary>
        public const string ESHOPORDERAFTERSTATUS_1 = "1";
        /// <summary>
        /// 处理中
        /// </summary>
        public const string ESHOPORDERAFTERSTATUS_2 = "2";
        /// <summary>
        /// 处理完成
        /// </summary>
        public const string ESHOPORDERAFTERSTATUS_3 = "3";
        /// <summary>
        /// 已取消售后
        /// </summary>
        public const string ESHOPORDERAFTERSTATUS_F1 = "-1";
        #endregion
        #region 支付方式
        /// <summary>
        /// 微信
        /// </summary>
        public const string PAYCHANNEL_1 = "1";

        /// <summary>
        /// 支付宝
        /// </summary>
        public const string PAYCHANNEL_2 = "2";

        #endregion

        #region 学历类型
        /// <summary>
        /// 大专
        /// </summary>
        public const string EDUCATIONTYPE_5 = "5";
        /// <summary>
        /// 本科
        /// </summary>
        public const string EDUCATIONTYPE_6 = "6";
        /// <summary>
        /// 研究生
        /// </summary>
        public const string EDUCATIONTYPE_7 = "7";
        #endregion
        #region 政治面貌类型
        /// <summary>
        /// 中共党员
        /// </summary>
        public const string POLITICSSTATUSTYPE_1 = "1";
        /// <summary>
        /// 共青团员
        /// </summary>
        public const string POLITICSSTATUSTYPE_3 = "3";
        /// <summary>
        /// 普通公民
        /// </summary>
        public const string POLITICSSTATUSTYPE_6 = "6";
        #endregion

        #region 抬头类型
        /// <summary>
        /// 企业单位
        /// </summary>
        public const string INVOICEOBJECTTYPE_1 = "1";
        /// <summary>
        /// 个人/非企业单位
        /// </summary>
        public const string INVOICEOBJECTTYPE_2 = "2";
        #endregion

        #region 发票类型
        /// <summary>
        /// 普通发票
        /// </summary>
        public const string INVOICETYPE_1 = "1";
        /// <summary>
        /// 专用发票
        /// </summary>
        public const string INVOICETYPE_2 = "2";
        #endregion

        #region 开票状态
        /// <summary>
        /// 未开票
        /// </summary>
        public const string INVOICESTATUS_0 = "0";
        /// <summary>
        /// 申请中
        /// </summary>
        public const string INVOICESTATUS_1 = "1";
        /// <summary>
        /// 已开票
        /// </summary>
        public const string INVOICESTATUS_2 = "2";
        #endregion
        #region 海报类型
        /// <summary>
        /// 积分商品海报
        /// </summary>
        public const string POSTERSTYPE_0 = "0";
        /// <summary>
        /// 活动海报
        /// </summary>
        public const string POSTERSTYPE_1 = "1";
        /// <summary>
        /// 通用模块
        /// </summary>
        public const string POSTERSTYPE_2 = "2";
        /// <summary>
        /// 秒杀商品海报
        /// </summary>
        public const string POSTERSTYPE_3 = "3";
        /// <summary>
        /// 邀请入会
        /// </summary>
        public const string POSTERSTYPE_4 = "4";
        /// <summary>
        /// 邀请海报
        /// </summary>
        public const string POSTERSTYPE_5 = "5";
        /// <summary>
        /// 长征海报
        /// </summary>
        public const string POSTERSTYPE_6 = "6";
        #endregion

        #region 活动方式
        /// <summary>
        /// 线上报名
        /// </summary>
        public const string ACTIVEPARTINWAYTYPE_1 = "1";
        /// <summary>
        /// 表单提交
        /// </summary>
        public const string ACTIVEPARTINWAYTYPE_2 = "2";
        #endregion

        #region 长征展示线路方式
        /// <summary>
        /// 地图展示
        /// </summary>
        public const string SHOWROUTEWAY_1 = "1";
        /// <summary>
        /// 图片展示
        /// </summary>
        public const string SHOWROUTEWAY_2 = "2";
        #endregion

        #region 券类型
        /// <summary>
        /// 咖啡无敌券
        /// </summary>
        public const string COUPONTYPE_1 = "1";
        /// <summary>
        /// 咖啡折扣券
        /// </summary>
        public const string COUPONTYPE_2 = "2";
        /// <summary>
        /// 生日券
        /// </summary>
        public const string COUPONTYPE_3 = "3";
        /// <summary>
        /// 购房优惠券
        /// </summary>
        public const string COUPONTYPE_4 = "4";
        /// <summary>
        /// 活动券
        /// </summary>
        public const string COUPONTYPE_5 = "5";
        /// <summary>
        /// 抖音活动券
        /// </summary>
        public const string COUPONTYPE_6 = "6";
        /// <summary>
        /// 潮one活动券
        /// </summary>
        public const string COUPONTYPE_7 = "7";
        /// <summary>
        /// 四季光年活动券
        /// </summary>
        public const string COUPONTYPE_8 = "8";
        /// <summary>
        /// 翡翠天域活动券
        /// </summary>
        public const string COUPONTYPE_9 = "9";
        /// <summary>
        /// 未来城活动券
        /// </summary>
        public const string COUPONTYPE_10 = "10";
        #endregion

        #region 券有效期类型
        /// <summary>
        /// 弹性时间
        /// </summary>
        public const string EFFECTTYPE_1 = "1";
        /// <summary>
        /// 固定时间
        /// </summary>
        public const string EFFECTTYPE_2 = "2";
        /// <summary>
        /// 当前月
        /// </summary>
        public const string EFFECTTYPE_3 = "3";
        #endregion

        #region 核销方式
        /// <summary>
        /// 二维码
        /// </summary>
        public const string CHECKWAY_1 = "1";
        /// <summary>
        /// 账号密码
        /// </summary>
        public const string CHECKWAY_2 = "2";

        #endregion

        #region 反馈类型
        /// <summary>
        /// 问题反馈
        /// </summary>
        public const string FEEDBACKTYPE_1 = "1";
        /// <summary>
        /// 业主认证
        /// </summary>
        public const string FEEDBACKTYPE_2 = "2";

        #endregion

        #region 盲盒活动类型
        /// <summary>
        /// 邀请人盲盒
        /// </summary>
        public const string BLINDBBOXACTIVETYPE_1 = "1";
        /// <summary>
        /// 被邀请人盲盒
        /// </summary>
        public const string BLINDBBOXACTIVETYPE_2 = "2";

        #endregion

        #region 盲盒活动订单状态
        /// <summary>
        /// 待到访
        /// </summary>
        public const string BLINDBBOXACTIVEORDERSTATUS_1 = "1";
        /// <summary>
        /// 已到访
        /// </summary>
        public const string BLINDBBOXACTIVEORDERSTATUS_2 = "2";
        /// <summary>
        /// 已完成（已核销）
        /// </summary>
        public const string BLINDBBOXACTIVEORDERSTATUS_3 = "3";
        /// <summary>
        /// 已完成（被邀请人领取盲盒）
        /// </summary>
        public const string BLINDBBOXACTIVEORDERSTATUS_4 = "4";
        /// <summary>
        /// 已完成（邀请人领取盲盒）
        /// </summary>
        public const string BLINDBBOXACTIVEORDERSTATUS_5 = "5";
        /// <summary>
        /// 已完成（都领取完盲盒）
        /// </summary>
        public const string BLINDBBOXACTIVEORDERSTATUS_6 = "6";
        #endregion

        #region 邀请类型
        /// <summary>
        /// 公寓
        /// </summary>
        public const string INVITATETYPE_1 = "1";
        /// <summary>
        /// 商铺
        /// </summary>
        public const string INVITATETYPE_2 = "2";
        /// <summary>
        /// 写字楼
        /// </summary>
        public const string INVITATETYPE_3 = "3";

        #endregion

        #region 用户标签
        /// <summary>
        /// 学生
        /// </summary>
        public const string USERLABELCODE_STUDENT = "student";
        /// <summary>
        /// 教师职工
        /// </summary>
        public const string USERLABELCODE_TEACHER = "teacher";
        /// <summary>
        /// ios俱乐部
        /// </summary>
        public const string USERLABELCODE_IOSCLUB = "iosClub";
        /// <summary>
        /// 普通员工
        /// </summary>
        public const string USERLABELCODE_COMMONEMPLOYEE = "commonEmployee";
        /// <summary>
        /// 编制员工
        /// </summary>
        public const string USERLABELCODE_ESTABLISHEDEMPLOYEE = "establishedEmployee";
        /// <summary>
        /// 业主
        /// </summary>
        public const string USERLABELCODE_OWNER = "owner";
        /// <summary>
        /// 住宅
        /// </summary>
        public const string USERLABELCODE_ZHUZHAI = "zhuZhai";
        /// <summary>
        /// 商铺
        /// </summary>
        public const string USERLABELCODE_SHANGPU = "shangPu";
        /// <summary>
        /// 公寓
        /// </summary>
        public const string USERLABELCODE_GONGYU = "gongYu";
        /// <summary>
        /// 办公
        /// </summary>
        public const string USERLABELCODE_BANGONG = "banGong";
        /// <summary>
        /// 其他
        /// </summary>
        public const string USERLABELCODE_QITA = "qiTa";
        /// <summary>
        /// A
        /// </summary>
        public const string USERLABELCODE_A = "a";
        /// <summary>
        /// B
        /// </summary>
        public const string USERLABELCODE_B = "b";
        /// <summary>
        /// C
        /// </summary>
        public const string USERLABELCODE_C = "c";
        /// <summary>
        /// D
        /// </summary>
        public const string USERLABELCODE_D = "d";
        /// <summary>
        /// 无效
        /// </summary>
        public const string USERLABELCODE_WUXIAO = "wuXiao";
        /// <summary>
        /// 认购住宅
        /// </summary>
        public const string USERLABELCODE_RENGOUZHUZHAI = "renGouZhuZhai";

        /// <summary>
        /// 认购商铺
        /// </summary>
        public const string USERLABELCODE_RENGOUSHANGPU = "renGouShangPu";

        /// <summary>
        /// 认购公寓
        /// </summary>
        public const string USERLABELCODE_RENGOUGONGYU = "renGouGongYu";

        /// <summary>
        /// 认购办公
        /// </summary>
        public const string USERLABELCODE_RENGOUBANGONG = "renGouBanGong";

        /// <summary>
        /// 上海嘉源VIP认证
        /// </summary>
        public const string USERLABELCODE_JIAYUANVIP = "jiayuanVip";

        /// <summary>
        /// 嘉兴万科会员卡
        /// </summary>
        public const string USERLABELCODE_JIAXINGMEMBERCARD = "jiaXingMemberCard";

        /// <summary>
        /// 宝丽星企业用户
        /// </summary>
        public const string USERLABELCODE_BLXQIYEYONGHU = "blxQiYeYongHu";
        /// <summary>
        /// 职工
        /// </summary>
        public const string USERLABELCODE_WORKER = "worker";

        /// <summary>
        /// 学校教师
        /// </summary>
        public const string USERLABELCODE_SCHOOLTEACHER = "schoolTeacher";
        /// <summary>
        /// 江苏第二师范远足社*iCreate Club
        /// </summary>
        public const string USERLABELCODE_ICREATECLUB = "iCreateClub";
        #endregion

        #region call客状态
        /// <summary>
        /// 主叫正常挂机
        /// </summary>
        public const string CALLSTATUS_0 = "0";
        /// <summary>
        /// 被叫正常挂机
        /// </summary>
        public const string CALLSTATUS_1 = "1";
        /// <summary>
        /// 用户忙
        /// </summary>
        public const string CALLSTATUS_2 = "2";
        /// <summary>
        /// 用户未响应
        /// </summary>
        public const string CALLSTATUS_3 = "3";
        /// <summary>
        /// 用户未应答
        /// </summary>
        public const string CALLSTATUS_4 = "4";
        /// <summary>
        /// 用户拒接
        /// </summary>
        public const string CALLSTATUS_5 = "5";
        /// <summary>
        /// 号码不存在
        /// </summary>
        public const string CALLSTATUS_6 = "6";
        /// <summary>
        /// 其他
        /// </summary>
        public const string CALLSTATUS_7 = "7";
        #endregion
        #region 绚集订单积分类型
        /// <summary>
        /// 现金赠送
        /// </summary>
        public const string XJPOINTORDER_XJCASHGIFT = "XjCashGift";
        /// <summary>
        /// 商品兑换
        /// </summary>
        public const string XJPOINTORDER_XJGOODSEXCHANGE = "XjGoodsExchange";
        /// <summary>
        /// 商城退单
        /// </summary>
        public const string XJPOINTORDER_XJPOINTORDERCENCER = "XjPointOrderCencer";
        /// <summary>
        /// 商品秒杀
        /// </summary>
        public const string XJPOINTORDER_XJSECKILLORDER = "XjSeckillOrder";
        #endregion
        #region 绚集抽奖商品类型
        /// <summary>
        /// 绚分
        /// </summary>
        public const string XJLUCKYDRAWACTIVEGOODSTYPE_1 = "1";
        /// <summary>
        /// 券
        /// </summary>
        public const string XJLUCKYDRAWACTIVEGOODSTYPE_2 = "2";
        /// <summary>
        /// 商品
        /// </summary>
        public const string XJLUCKYDRAWACTIVEGOODSTYPE_3 = "3";
        /// <summary>
        /// 谢谢惠顾
        /// </summary>
        public const string XJLUCKYDRAWACTIVEGOODSTYPE_4 = "4";
        #endregion

        #region 绚集盲盒抽奖物品类型
        /// <summary>
        /// 积分
        /// </summary>
        public const string XJBLINDBBOXGOODSTYPE_1 = "1";
        /// <summary>
        /// 商品
        /// </summary>
        public const string XJBLINDBBOXGOODSTYPE_2 = "2";
        /// <summary>
        /// 折扣券
        /// </summary>
        public const string XJBLINDBBOXGOODSTYPE_3 = "3";
        /// <summary>
        /// 火力值
        /// </summary>
        public const string XJBLINDBBOXGOODSTYPE_4 = "4";
        #endregion

        #region call客用户来源
        /// <summary>
        /// 分配客户
        /// </summary>
        public const string CALLKESOURCEFROM_1 = "1";
        /// <summary>
        /// 接待客户
        /// </summary>
        public const string CALLKESOURCEFROM_2 = "2";
        /// <summary>
        /// 外展外拓
        /// </summary>
        public const string CALLKESOURCEFROM_3 = "3";
        /// <summary>
        /// 线上客户
        /// </summary>
        public const string CALLKESOURCEFROM_4 = "4";

        #endregion

        #region 维修状态
        /// <summary>
        /// 草稿
        /// </summary>
        public const string REPAIRSTATUS_0 = "0";
        /// <summary>
        /// 待处理
        /// </summary>
        public const string REPAIRSTATUS_1 = "1";
        /// <summary>
        /// 已接单
        /// </summary>
        public const string REPAIRSTATUS_2 = "2";
        /// <summary>
        /// 已完成
        /// </summary>
        public const string REPAIRSTATUS_3 = "3";
        /// <summary>
        /// 已取消
        /// </summary>
        public const string REPAIRSTATUS_4 = "4";

        #endregion

        #region 核销二维码type
        /// <summary>
        /// 商城订单
        /// </summary>
        public const string VERIFICATECODETYPE_1 = "1";

        /// <summary>
        /// 知味食光订单
        /// </summary>
        public const string VERIFICATECODETYPE_2 = "2";

        /// <summary>
        /// 活动
        /// </summary>
        public const string VERIFICATECODETYPE_3 = "3";

        /// <summary>
        /// 抽奖商品核销
        /// </summary>
        public const string VERIFICATECODETYPE_4 = "4";
        /// <summary>
        /// 资产核销(子单核销)
        /// </summary>
        public const string VERIFICATECODETYPE_5 = "5";
        /// <summary>
        /// 车辆预约送积分
        /// </summary>
        public const string VERIFICATECODETYPE_6 = "6";
        /// <summary>
        /// 生日到店送积分
        /// </summary>
        public const string VERIFICATECODETYPE_7 = "7";
        /// <summary>
        /// 资产核销(主单核销)
        /// </summary>
        public const string VERIFICATECODETYPE_8 = "8";
        /// <summary>
        /// 购房优惠券核销
        /// </summary>
        public const string VERIFICATECODETYPE_9 = "9";
        /// <summary>
        /// 电商订单核销
        /// </summary>
        public const string VERIFICATECODETYPE_10 = "10";
        /// <summary>
        /// 外展外扩活动券核销
        /// </summary>
        public const string VERIFICATECODETYPE_11 = "11";
        /// <summary>
        /// 盲盒活动订单核销
        /// </summary>
        public const string VERIFICATECODETYPE_12 = "12";
        /// <summary>
        /// 绚集积分商品(绚集积分商品、券商品、秒杀商品、盲盒商品订单核销)
        /// </summary>
        public const string VERIFICATECODETYPE_24 = "24";
        /// <summary>
        /// 绚集轮盘中奖记录核销
        /// </summary>
        public const string VERIFICATECODETYPE_25 = "25";
        /// <summary>
        /// 绚集翻牌中奖记录核销
        /// </summary>
        public const string VERIFICATECODETYPE_26 = "26";
        /// <summary>
        /// 绚集活动核销
        /// </summary>
        public const string VERIFICATECODETYPE_27 = "27";
        /// <summary>
        /// 砍一刀商品订单核销
        /// </summary>
        public const string VERIFICATECODETYPE_32 = "32";
        /// <summary>
        /// 商铺商品券核销
        /// </summary>
        public const string VERIFICATECODETYPE_33 = "33";
        /// <summary>
        /// 翻牌抽奖物品核销
        /// </summary>
        public const string VERIFICATECODETYPE_34 = "34";
        /// <summary>
        /// 砸金蛋物品核销
        /// </summary>
        public const string VERIFICATECODETYPE_37 = "37";
        /// <summary>
        /// 掷骰子物品核销
        /// </summary>
        public const string VERIFICATECODETYPE_39 = "39";
        /// <summary>
        /// 预约活动核销
        /// </summary>
        public const string VERIFICATECODETYPE_40 = "40";
        /// <summary>
        /// 门店券商品核销
        /// </summary>
        public const string VERIFICATECODETYPE_41 = "41";
        /// <summary>
        /// 光合岛集-市场活动核销
        /// </summary>
        public const string VERIFICATECODETYPE_42 = "42";
        /// <summary>
        /// 光合岛集-艺术馆活动核销
        /// </summary>
        public const string VERIFICATECODETYPE_45 = "45";
        /// <summary>
        /// 盐城万科私宴核销
        /// </summary>
        public const string VERIFICATECODETYPE_46 = "46";
        #endregion

        #region 海报二维码type

        /// <summary>
        /// 商城商品海报
        /// </summary>
        public const string POSTERCODETYPE_0 = "0";
        /// <summary>
        /// 活动
        /// </summary>
        public const string POSTERCODETYPE_1 = "1";
        /// <summary>
        /// 通用模块
        /// </summary>
        public const string POSTERCODETYPE_2 = "2";
        /// <summary>
        /// 商品
        /// </summary>
        public const string POSTERCODETYPE_3 = "3";
        /// <summary>
        /// 员工邀请
        /// </summary>
        public const string POSTERCODETYPE_4 = "4";
        /// <summary>
        /// 邀请海报
        /// </summary>
        public const string POSTERCODETYPE_5 = "5";
        /// <summary>
        /// 长征海报
        /// </summary>
        public const string POSTERCODETYPE_6 = "6";
        /// <summary>
        /// 抽奖活动助力
        /// </summary>
        public const string POSTERCODETYPE_7 = "7";
        /// <summary>
        /// 在售项目商铺
        /// </summary>
        public const string POSTERCODETYPE_8 = "8";
        /// <summary>
        /// 在售项目住宅
        /// </summary>
        public const string POSTERCODETYPE_9 = "9";
        /// <summary>
        /// 我的二维码
        /// </summary>
        public const string POSTERCODETYPE_10 = "10";
        /// <summary>
        /// 外拓二维码
        /// </summary>
        public const string POSTERCODETYPE_11 = "11";
        /// <summary>
        /// 机器码
        /// </summary>
        public const string POSTERCODETYPE_12 = "12";
        /// <summary>
        /// 机构信息
        /// </summary>
        public const string POSTERCODETYPE_13 = "13";
        /// <summary>
        /// 盲盒活动邀请看房
        /// </summary>
        public const string POSTERCODETYPE_14 = "14";
        /// <summary>
        /// 销售评分二维码
        /// </summary>
        public const string POSTERCODETYPE_15 = "15";
        /// <summary>
        /// 绚集-海报转发
        /// </summary>
        public const string POSTERCODETYPE_16 = "16";
        /// <summary>
        /// 绚集积分商品
        /// </summary>
        public const string POSTERCODETYPE_17 = "17";
        /// <summary>
        /// 绚集活动
        /// </summary>
        public const string POSTERCODETYPE_18 = "18";
        /// <summary>
        /// 绚集抽奖助力
        /// </summary>
        public const string POSTERCODETYPE_19 = "19";
        /// <summary>
        /// 绚集翻牌
        /// </summary>
        public const string POSTERCODETYPE_20 = "20";
        /// <summary>
        /// 绚集外拓活动
        /// </summary>
        public const string POSTERCODETYPE_21 = "21";
        /// <summary>
        /// 绚集券商品
        /// </summary>
        public const string POSTERCODETYPE_22 = "22";
        /// <summary>
        /// 绚集秒杀商品
        /// </summary>
        public const string POSTERCODETYPE_23 = "23";
        /// <summary>
        /// 绚集积分商品(绚集积分、秒杀、盲盒抽奖、券商品核销)
        /// </summary>
        public const string POSTERCODETYPE_24 = "24";
        /// <summary>
        /// 绚集轮盘中奖记录核销
        /// </summary>
        public const string POSTERCODETYPE_25 = "25";
        /// <summary>
        /// 绚集翻牌中奖记录核销
        /// </summary>
        public const string POSTERCODETYPE_26 = "26";
        /// <summary>
        /// 绚集活动核销
        /// </summary>
        public const string POSTERCODETYPE_27 = "27";
        /// <summary>
        /// 转盘海报
        /// </summary>
        public const string POSTERCODETYPE_28 = "28";
        /// <summary>
        /// 业主领明信片礼包
        /// </summary>
        public const string POSTERCODETYPE_29 = "29";
        /// <summary>
        /// 砍一刀分享与海报
        /// </summary>
        public const string POSTERCODETYPE_30 = "30";
        /// <summary>
        /// 砍一刀商品邀请
        /// </summary>
        public const string POSTERCODETYPE_31 = "31";
        /// <summary>
        /// 砍一刀商品订单核销
        /// </summary>
        public const string POSTERCODETYPE_32 = "32";
        /// <summary>
        /// 翻牌抽奖助力
        /// </summary>
        public const string POSTERCODETYPE_35 = "35";
        /// <summary>
        /// 砸金蛋助力
        /// </summary>
        public const string POSTERCODETYPE_36 = "36";
        /// <summary>
        /// 预约商品海报
        /// </summary>
        public const string POSTERCODETYPE_41 = "41";

        /// <summary>
        /// 市场活动海报
        /// </summary>
        public const string POSTERCODETYPE_42 = "42";

        /// <summary>
        /// 快闪店海报
        /// </summary>
        public const string POSTERCODETYPE_43 = "43";

        /// <summary>
        /// 快闪店商品海报
        /// </summary>
        public const string POSTERCODETYPE_44 = "44";

        /// <summary>
        /// 艺术馆活动海报
        /// </summary>
        public const string POSTERCODETYPE_45 = "45";
        #endregion

        #region 短视频状态
        /// <summary>
        /// 草稿
        /// </summary>
        public const string VIDEOINFOSTATUS_0 = "0";

        /// <summary>
        /// 待处理
        /// </summary>
        public const string VIDEOINFOSTATUS_1 = "1";
        /// <summary>
        /// 已通过
        /// </summary>
        public const string VIDEOINFOSTATUS_2 = "2";
        /// <summary>
        /// 已拒绝
        /// </summary>
        public const string VIDEOINFOSTATUS_3 = "3";

        #endregion


        #region 折扣券类型
        /// <summary>
        /// 代金券
        /// </summary>
        public const string DISCOUNTCOUPONTYPE_1 = "1";
        /// <summary>
        /// 折扣券
        /// </summary>
        public const string DISCOUNTCOUPONTYPE_2 = "2";
        #endregion

        #region 卡密分配方式
        /// <summary>
        /// 商城兑换
        /// </summary>
        public const string PRODUCTCARDPASSWORDALLOTTYPE_1 = "1";
        /// <summary>
        /// 秒杀
        /// </summary>
        public const string PRODUCTCARDPASSWORDALLOTTYPE_2 = "2";
        /// <summary>
        /// 转盘抽奖
        /// </summary>
        public const string PRODUCTCARDPASSWORDALLOTTYPE_3 = "3";
        /// <summary>
        /// 盲盒签到
        /// </summary>
        public const string PRODUCTCARDPASSWORDALLOTTYPE_4 = "4";
        /// <summary>
        /// 掷骰子
        /// </summary>
        public const string PRODUCTCARDPASSWORDALLOTTYPE_5 = "5";
        /// <summary>
        /// 砸金蛋
        /// </summary>
        public const string PRODUCTCARDPASSWORDALLOTTYPE_6 = "6";
        /// <summary>
        /// 翻牌抽奖
        /// </summary>
        public const string PRODUCTCARDPASSWORDALLOTTYPE_7 = "7";
        #endregion

        #region 短视频类型

        /// <summary>
        /// 视频
        /// </summary>
        public const string VIDEOSHOWTYPE_1 = "1";
        /// <summary>
        /// 多图
        /// </summary>
        public const string VIDEOSHOWTYPE_2 = "2";
      

        #endregion
        #endregion
        #region 商品无敌券目录id
        /// <summary>
        /// 商品无敌券目录id
        /// </summary>
        public const long CouponCrgtId = 146576604402941952;
        #endregion

        #region 消息订阅类型
        /// <summary>
        /// 签到提醒订阅
        /// </summary>
        public const string TEMPLATETYPE_QIANDAO = "QianDao";
        /// <summary>
        /// 公司公告订阅
        /// </summary>
        public const string TEMPLATETYPE_GONGSIGONGGAO = "GongSiGongGao";
        /// <summary>
        /// 活动上新订阅
        /// </summary>
        public const string TEMPLATETYPE_XINHUODONG = "XinHuoDong";
        /// <summary>
        /// 新品上新订阅
        /// </summary>
        public const string TEMPLATETYPE_XINPINSHANGXIN = "XinPinShangXin";
        /// <summary>
        /// 助力订阅
        /// </summary>
        public const string TEMPLATETYPE_HAOYOUZHULI = "HaoYouZhuLi";

        /// <summary>
        /// 活动参与奖励通知
        /// </summary>
        public const string TEMPLATETYPE_HUODONGCANYUJIANGLI = "HuoDongCanYuJiangLi";
        /// <summary>
        /// 优惠券到账提醒
        /// </summary>
        public const string TEMPLATETYPE_YOUHUIQUANDAOZHANG = "YouHuiQuanDaoZhang";
        /// <summary>
        /// 认证结果通知
        /// </summary>
        public const string TEMPLATETYPE_RENZHENGJIEGUO = "RenZhengJieGuo";
        /// <summary>
        /// 新用户注册通知
        /// </summary>
        public const string TEMPLATETYPE_XINKEHUZHUCE = "XinKeHuZhuCe";
        /// <summary>
        /// 新评论通知
        /// </summary>
        public const string TEMPLATETYPE_XINPINGLUN = "XinPingLun";

        /// <summary>
        /// 绚集活动参与奖励通知
        /// </summary>
        public const string TEMPLATETYPE_XJHUODONGCANYUJIANGLI = "XuanJiZhuanPanHuoDongCanYuJiangLi";

        /// <summary>
        /// 绚集助力订阅
        /// </summary>
        public const string TEMPLATETYPE_XJHAOYOUZHULI = "XuanJiZhuanPanHaoYouZhuLi";

        /// <summary>
        /// 绚集活动上新订阅
        /// </summary>
        public const string TEMPLATETYPE_XJXINHUODONG = "XuanJiXinHuoDong";
        /// <summary>
        /// 绚集自助绚分订阅
        /// </summary>
        public const string TEMPLATETYPE_XJZIZHUXUANFEN = "XuanJiZiZhuXuanFen";

        /// <summary>
        /// 砍价助力订阅
        /// </summary>
        public const string TEMPLATETYPE_KANJIAZHULI = "KanJiaZhuLi";

        /// <summary>
        /// 新报修提醒
        /// </summary>
        public const string TEMPLATETYPE_XINBAOXIUTIXING = "XinBaoXiuTiXing";

        /// <summary>
        /// 工单派工通知
        /// </summary>
        public const string TEMPLATETYPE_GONGDANPAIXIUTONGZHI = "GongDanPaiXiuTongZhi";

        /// <summary>
        /// 评分结果通知
        /// </summary>
        public const string TEMPLATETYPE_PINGFENJIEGUOTONGZHI = "PingFenJieGuoTongZhi";

        /// <summary>
        /// 翻牌活动参与奖励通知
        /// </summary>
        public const string TEMPLATETYPE_FANPAIHUODONGCANYUJIANGLI = "FanPaiHuoDongCanYuJiangLi";

        /// <summary>
        /// 翻牌好友助力提醒
        /// </summary>
        public const string TEMPLATETYPE_FANPAIHAOYOUZHULI = "FanPaiHaoYouZhuLi";


        /// <summary>
        /// 砸金蛋活动参与奖励通知
        /// </summary>
        public const string TEMPLATETYPE_ZAJINDANHUODONGCANYUJIANGLI = "ZaJinDanHuoDongCanYuJiangLi";

        /// <summary>
        /// 砸金蛋好友助力提醒
        /// </summary>
        public const string TEMPLATETYPE_ZAJINDANHAOYOUZHULI = "ZaJinDanHaoYouZhuLi";

        /// <summary>
        /// 投骰子活动参与奖励通知
        /// </summary>
        public const string TEMPLATETYPE_ZHITOUZIHUODONGCANYUJIANGLI = "ZhiTouZiHuoDongCanYuJiangLi";

        /// <summary>
        /// 投骰子好友助力提醒
        /// </summary>
        public const string TEMPLATETYPE_ZHITOUZIHAOYOUZHULI = "ZhiTouZiHaoYouZhuLi";

        /// <summary>
        /// Vip认证结果通知
        /// </summary>
        public const string TEMPLATETYPE_VIPRENZHENGJIEGUO = "VipRenZhengJieGuo";

        /// <summary>
        /// 账户变动提醒
        /// </summary>
        public const string TEMPLATETYPE_ZHANGHUBIANDONGTIXING = "ZhangHuBianDongTiXing";
        /// <summary>
        /// 市集活动上新
        /// </summary>
        public const string TEMPLATETYPE_GHDJ_SJXINHUODONG = "GHDJ_SjXinHuoDong";

        /// <summary>
        /// 水吧台新订单通知
        /// </summary>
        public const string TEMPLATETYPE_SHUIBATAIXINDINGDAN = "ShuiBaTaiXinDingDan";

        /// <summary>
        /// 水吧台订单完成通知
        /// </summary>
        public const string TEMPLATETYPE_SHUIBATAIDINGDANWANCHENG = "ShuiBaTaiDingDanWanCheng";

        /// <summary>
        /// 私宴预约待审核通知
        /// </summary>
        public const string TEMPLATETYPE_YUYUEDAISHENHETONGZHI = "YuYueDaiShenHeTongZhi";

        /// <summary>
        /// 私宴预约审核完成通知
        /// </summary>
        public const string TEMPLATETYPE_YUYUESHENHEWANCHENGTONGZHI = "YuYueShenHeWanChengTongZhi";

        /// <summary>
        /// 视频待审核通知
        /// </summary>
        public const string TEMPLATETYPE_SHIPINDAISHENHETONGZHI = "ShiPinDaiShenHeTongZhi";

        /// <summary>
        /// 视频审核完成通知
        /// </summary>
        public const string TEMPLATETYPE_SHIPINSHENHEWANCHENGTONGZHI = "ShiPinShenHeWanChengTongZhi";

        /// <summary>
        /// 砍价成功提醒
        /// </summary>
        public const string TEMPLATETYPE_KANJIACHENGGONGTIXING = "KanJiaChengGongTiXing";
        #endregion

        #region 商家抵用券id
        public const long CTGRVOUCHERSID = 111151540588249088;
        #endregion

        #region 项目编号

        /// <summary>
        /// 中海地产
        /// </summary>
        public const string PRODUCTCODE_CHINAOVERSEAS = "china-overseas";

        /// <summary>
        /// 南京万科
        /// </summary>
        public const string PRODUCTCODE_NANJINGVANKE = "nan-jing-vanke";

        /// <summary>
        /// 镇江万科
        /// </summary>
        public const string PRODUCTCODE_ZHENJIANGVANKE = "zhen-jiang-vanke";

        /// <summary>
        /// 公版咖啡
        /// </summary>
        public const string PRODUCTCODE_COFFEEHALLWAY = "coffee-hallway";

        /// <summary>
        /// 一技教育
        /// </summary>
        public const string PRODUCTCODE_TECHNICALEDUCATION = "technical-education";

        /// <summary>
        /// 中升恒岳
        /// </summary>
        public const string PRODUCTCODE_ZHONGSHENGHENGYUE = "zhong-sheng-heng-yue";

        /// <summary>
        /// 云走廊南京
        /// </summary>
        public const string PRODUCTCODE_CLOUDCORRIDOR = "cloud-corridor";

        /// <summary>
        /// java自动服务配置，配置不同的项目和任务
        /// </summary>
        public const string PRODUCTCODE_JAVAAUTOSERVICE = "java-auto-service";

        /// <summary>
        /// 交警五大队
        /// </summary>
        public const string PRODUCTCODE_TRAFFICPOLICEFIVETEAMS = "traffic-police-five-teams";
        /// <summary>
        /// 宝丽星商城
        /// </summary>
        public const string PRODUCTCODE_BAOLIXINGSHOP = "baolixing-shop";
        /// <summary>
        /// 嘉兴万科
        /// </summary>
        public const string PRODUCTCODE_JIAXINGVANKE = "jia-xing-vanke";
        /// <summary>
        /// 中南地产
        /// </summary>
        public const string PRODUCTCODE_ZHONGNAN = "zhong-nan";
        /// <summary>
        /// 中信保诚
        /// </summary>
        public const string PRODUCTCODE_CITICPRUDENTIAL = "citic-prudential";
        /// <summary>
        /// 替替电子
        /// </summary>
        public const string PRODUCTCODE_TITIDIANZI = "titi-dianzi";
        /// <summary>
        /// 青岛金隅
        /// </summary>
        public const string PRODUCTCODE_QINGDAOJINYU = "qingdao-jinyu";
        /// <summary>
        /// 盐城万科
        /// </summary>
        public const string PRODUCTCODE_YANCHENGVANKE = "yan-cheng-vanke";
        #endregion

        #region 支付模式
        /// <summary>
        /// 纯积分模式
        /// </summary>
        public const string PAYWAY_POINT = "Point";
        /// <summary>
        /// 纯现金模式
        /// </summary>
        public const string PAYWAY_CASH = "Cash";
        /// <summary>
        /// 积分+现金模式
        /// </summary>
        public const string PAYWAY_CASHANDPOINT = "CashAndPoint";
        #endregion

        #region 用户来源类型
        /// <summary>
        /// 散客
        /// </summary>
        public const long SOURCEFROM_0 = 0;
        /// <summary>
        /// 销售顾问集客
        /// </summary>
        public const long SOURCEFROM_1 = 1;
        /// <summary>
        /// 转发
        /// </summary>
        public const long SOURCEFROM_3 = 3;
        /// <summary>
        /// 海报分享
        /// </summary>
        public const long SOURCEFROM_4 = 4;
        #endregion

        #region 特殊商品目录编号
        /// <summary>
        /// 老业主
        /// </summary>
        public const string CAGECODE_OLDUSER = "OldUser";

        /// <summary>
        /// 员工
        /// </summary>
        public const string CAGECODE_ESTABLISHEDEMPLOYEE = "EstablishedEmployee";

        /// <summary>
        /// 仅限新用户
        /// </summary>
        public const string CAGECODE_ONLYNEW = "OnlyNew";

        /// <summary>
        /// 春日计划
        /// </summary>
        public const string CAGECODE_SPRINGPRESENT = "SpringPresent";
        /// <summary>
        /// 惠易捷盲盒机
        /// </summary>
        public const string CAGECODE_HUIYIJIEVENDINGMACHINE = "HuiYiJieVendingMachine";
        #endregion

    }
}
