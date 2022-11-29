﻿namespace Cloud.Models
{
    public class AjaxResponse
    {
        /// <summary>
        /// 1：成功  0：失败
        /// </summary>
        public int Code { get; set; } = 0;

        /// <summary>
        /// 返回的提示信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据集
        /// </summary>
        public dynamic Data { get; set; }
    }
}
