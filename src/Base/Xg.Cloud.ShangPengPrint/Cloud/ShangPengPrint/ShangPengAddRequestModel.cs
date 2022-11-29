namespace Cloud.ShangPengPrint
{
    public class ShangPengAddRequestModel
    {
        public string Appid { get; set; }

        public int Timestamp { get; set; }


        /// <summary>
        /// 打印机编号
        /// </summary>
        public string Sn { get; set; }

        public string Pkey { get; set; }

        public string Name { get; set; }

        public string Sign { get; set; }
    }
}
