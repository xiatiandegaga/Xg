namespace Cloud.ShangPengPrint
{
    public class ShangPengOptions
    {
        /// <summary>
        /// 域名地址
        /// </summary>
        public string DomainUrl { get; set; }
        /// <summary>
        /// action 删除打印机订单
        /// </summary>
        public string ActionDeleteUrl { get; set; }
        /// <summary>
        /// action 添加打印机
        /// </summary>
        public string ActionAddUrl { get; set; }
        /// <summary>
        /// action 打印订单
        /// </summary>
        public string ActionPrintUrl { get; set; }
        /// <summary>
        /// action 查询订单
        /// </summary>
        public string ActionQueryUrl { get; set; }
        public string Appid { get; set; }

        public string AppSecret { get; set; }
    }
}
