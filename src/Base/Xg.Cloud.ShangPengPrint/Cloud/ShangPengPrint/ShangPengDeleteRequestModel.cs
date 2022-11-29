namespace Cloud.ShangPengPrint
{
    public class ShangPengDeleteRequestModel
    {

        public string Appid { get; set; }

        public int Timestamp { get; set; }


        /// <summary>
        /// 打印机编号
        /// </summary>
        public string Sn { get; set; }


        public string Sign { get; set; }
    }
}
