using Application;
using Application.Dto;
using Cloud.Models;
using Cloud.Utilities;
using Domain.Entity;
using Domain.Model;
using Identity.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityApi.Controllers.BasicController
{
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly UserApp _userApp;
        private readonly AuthenticationApp _authApp;
        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _configuration;
        public LoginController(UserApp userApp, AuthenticationApp authApp, ILogger<LoginController> logger, IConfiguration configuration)
        {
            _userApp = userApp;
            _authApp = authApp;
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        ///  AccountLogin
        /// </summary>
        /// <param name="dtoUser"></param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public async Task<AjaxResponse> AccountLogin([FromBody] RequestLoginUser dtoUser)
        {
            var user = await _authApp.AccountLoginAsync(dtoUser.Account.Trim(), dtoUser.Password.Trim());
            if (user == null) return new AjaxResponse { Code = 0, Msg = "Account or  Password Error " };
            return new AjaxResponse { Code = 1, Data = new { Token = _authApp.SignIn(user), user.Name, Avatar = user.Img } };

        }
        /// <summary>
        /// AccountForMobile
        /// </summary>
        /// <param name="model">user</param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public async Task<AjaxResponse> AccountForMobile([FromBody] LoginForMobileModel model)
        {
            if (string.IsNullOrEmpty(model.Mobile))
            {
                return new AjaxResponse { Code = 0, Msg = "Mobile Empty" };
            }
            if (string.IsNullOrEmpty(model.Code))
            {
                return new AjaxResponse { Code = 0, Msg = "Code Empty" };
            }
            if (!await _userApp.CheckMobileVerifyCodeAsync(model.Mobile, model.Code))
            {
                return new AjaxResponse { Code = 0, Msg = "Code  Error" };
            }
            var user = _userApp.FindSingleByAccount(model.Mobile);
            return new AjaxResponse { Code = 1, Data = new { Token = _authApp.SignIn(user), user.Name, Avatar = user.Img } };
        }

        /// <summary>
        /// AccountLoginForCode
        /// </summary>
        /// <param name="dtoUser">user</param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public async Task<AjaxResponse> AccountLoginForCode([FromBody] RequestLoginUser dtoUser)
        {
            if (string.IsNullOrEmpty(dtoUser.Code))
            {
                return new AjaxResponse { Code = 0, Msg = "Code Empty" };
            }
            if (!await _userApp.CheckVerifyCodeAsync(dtoUser.Code))
            {
                return new AjaxResponse { Code = 0, Msg = "Code Error" };
            }
            var user = await _authApp.AccountLoginAsync(dtoUser.Account, dtoUser.Password);
            if (user == null)
            {
                return new AjaxResponse { Code = 0, Msg = "Account or  Password Error " };
            }
            return new AjaxResponse { Code = 1, Data = new { Token = _authApp.SignIn(user), user.Name, Avatar = user.Img } };
        }

        /// <summary>
        /// GetAuthenticatedUser
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<AjaxResponseGen<UserListDto>> GetAuthenticatedUser()
        {
            var user = await _authApp.GetAuthUserDtoAsync();
            if (user == null)
            {
                return new AjaxResponseGen<UserListDto> { Code = 0, Msg = "User Error" };

            }
            return new AjaxResponseGen<UserListDto> { Code = 1, Data = user };
        }

        /// <summary>
        /// download excel
        /// </summary>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public FileContentResult DumpSampleReportExcel()
        {

            var lst = new List<User>
            {
               new User{Name="1",Sex=2 },
               new User{Name="2",Sex=2 }
            };
            return File(ExcelUtility.DumpExcel(lst.CopyToDataTable()), "application/ms-excel", "info" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + ".xlsx");
        }
    }
}
