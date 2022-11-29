using Cloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SkuQueryModel: Pagination
    {
        /// <summary>
        /// 商品类型id
        /// </summary>
        public long GoodsTypeId { get; set; }
        /// <summary>
        /// 商品目录（包括一级 二级目录）
        /// </summary>
        public List<long> CatgIdList { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public long FieldId { get; set; }
    }
}
