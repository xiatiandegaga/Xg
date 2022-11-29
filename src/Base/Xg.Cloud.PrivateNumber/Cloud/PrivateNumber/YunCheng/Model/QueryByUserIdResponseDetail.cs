using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.PrivateNumber.YunCheng.Model
{
    public class QueryByUserIdResponseDetail
    {
        public string Caller { get; set; }
        public string DstVirtualNum { get; set; }
        public string BindId { get; set; }
        public string BindTime { get; set; }
        public string MaxAge { get; set; }
        public string Record { get; set; }
        public string CallerDisplay { get; set; }
    }
}
