using Cloud.AutoMapper;
using Cloud.Caching;
using Cloud.Models;
using Cloud.Repositories;
using Domain.Entity;
using Domain.Interface;
using Domain.Model;
using Identity.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application
{
    public class UserApp
    {
        private readonly ICacheRepository<User> _cacheUserRepository;
        private readonly IUserService _userService;
        private readonly IAuthenticationPrincipalService _authenticationService;
        private readonly IRepository<User> _userRepository;
        public UserApp(ICacheRepository<User> cacheUserRepository, IUserService userService, IAuthenticationPrincipalService authenticationService, IRepository<User> userRepository)
        {
            _cacheUserRepository = cacheUserRepository;
            _userService = userService;
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }

        public async Task<List<UserListDto>> GetUsersAsync(int pageIndex, int pageSize, Expression<Func<User, bool>> express)
        {
            var list = (await _cacheUserRepository.FindByPageAsync(pageIndex, pageSize, express, "CreateDate Desc", u => u.UserRoles)).MapToIEnumerable<User, UserListDto>().ToList();
            return list;
        }
        public int GetUsersNum(Expression<Func<User, bool>> lstExpress) => _cacheUserRepository.GetCount(lstExpress, u => u.UserRoles);

        public async Task<bool> CheckVerifyCodeAsync(string code) => await _authenticationService.CheckVerifyCodeAsync(code);

        public IEnumerable<User> FindByPage(int pageIndex, int pageSize, Expression<Func<User, bool>> express)
        {
            return _userRepository.FindByPage(pageIndex, pageSize, express, "Id desc");
        }

        public IEnumerable<User> GetUserByListId(List<long> listId) => _cacheUserRepository.Find(x => listId.Contains(x.Id), "", u => u.UserRoles);

        /// <summary>
        /// GetMobileVerifyCodeAsync
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="cachingExpireType"></param>
        /// <returns></returns>
        public async Task<string> GetMobileVerifyCodeAsync(string mobile, CachingExpireType cachingExpireType = CachingExpireType.MobileCodeVerify)
        {
            if (!_userRepository.IsExist(x => x.Account == mobile && x.Password != "")) throw new MyException("该手机号尚未开通登录权限！", 0);
            return await _authenticationService.GetMobileVerifyCodeAsync(mobile, cachingExpireType);
        }

        /// <summary>
        /// CheckMobileVerifyCodeAsync
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<bool> CheckMobileVerifyCodeAsync(string mobile, string code)
            => await _authenticationService.CheckMobileVerifyCodeAsync(mobile, code);

        /// <summary>
        ///FindSingleByAccount
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public User FindSingleByAccount(string mobile)
            => _userRepository.FindSingle(x => x.Account == mobile);
    }
}
