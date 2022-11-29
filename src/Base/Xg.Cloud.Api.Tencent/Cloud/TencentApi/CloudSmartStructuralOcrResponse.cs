using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.TencentApi
{
    public class CloudSmartStructuralOcrResponse
    {
        /// <summary>
        /// 认证姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 认证学校
        /// </summary>
        public string School { get; set; }
        /// <summary>
        /// 认证code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 学籍状态名称
        /// </summary>
        public string StudentStatusName { get; set; }

        /// <summary>
        /// 学籍状态（1：有效  0：无效）
        /// </summary>
        public int StudentStatus
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StudentStatusName) || StudentStatusName.Substring(0, 4) != "注册学籍")
                    return 0;
                else
                    return 1;
            }
        }
    }
}
