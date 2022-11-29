namespace Cloud.ShangPengPrint
{
    public class ShangPengQueryRequestModel
    {
        public string Appid { get; set; }

        public int Timestamp { get; set; }


        /// <summary>
        /// 打印订单ID
        /// </summary>
        public string Id { get; set; }


        public string Sign { get; set; }
    }
}
