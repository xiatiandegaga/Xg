namespace Cloud.ShangPengPrint
{
    public class ShangPengPrintRequestModel
    {
        public string Appid { get; set; }

        public int Timestamp { get; set; }

        /// <summary>
        /// 打印内容，最大支持5000字节
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 打印机编号
        /// </summary>
        public string Sn { get; set; }

        /// <summary>
        /// 打印次数，默认为1，范围为1-5
        /// </summary>
        public int Times { get; set; } = 1;

        /// <summary>
        /// 对参数按照key=value的格式，并按照参数名ASCII字典序排序如下：
        /// </summary>
        public string Sign { get; set; }


    }
}
