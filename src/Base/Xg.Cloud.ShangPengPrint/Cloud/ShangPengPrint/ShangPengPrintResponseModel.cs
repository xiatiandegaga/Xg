namespace Cloud.ShangPengPrint
{
    public class ShangPengPrintResponseModel
    {
        /// <summary>
        /// 0:正确  1：打印机编号为空  2：打印机KEY为空  3:打印机名称为空
        /// </summary>
        public int Errorcode { get; set; }

        public string Errormsg { get; set; }

        public string Id { get; set; }
    }
}
