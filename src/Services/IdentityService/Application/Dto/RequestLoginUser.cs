namespace Application.Dto
{
    /// <summary>
    /// 登录请求的用户
    /// </summary>
    public class RequestLoginUser
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
    }
}
