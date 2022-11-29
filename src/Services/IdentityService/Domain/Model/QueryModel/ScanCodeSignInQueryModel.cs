using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ScanCodeSignInQueryModel
    {
        /// <summary>
        /// 盲盒订单id
        /// </summary>
        public long BlindBboxActiveOrderId { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public long FieldId { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public decimal? Lng { get; set; }
        /// <summary>
        /// 维度
        /// </summary>
        public decimal? Lat { get; set; }
    }
}
