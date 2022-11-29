using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.HuiYiJie.Model
{
    public abstract class BaseRes
    {
        /// <summary>
        /// 结果，200代表正常
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 结果描述
        /// </summary>
        public string ResultDesc { get; set; }

    }
}
