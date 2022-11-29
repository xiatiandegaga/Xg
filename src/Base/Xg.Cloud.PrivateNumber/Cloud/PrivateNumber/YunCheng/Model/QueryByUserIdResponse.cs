using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.PrivateNumber.YunCheng.Model
{
    public class QueryByUserIdResponse
    {
        public string Result { get; set; }

        public string Message { get; set; }

        public   ICollection<QueryByUserIdResponseDetail> Data { get; set; }
    }
}
