using Cloud.AutoMapper;
using Cloud.Extensions;
using Cloud.Models;
using Cloud.Repositories;
using Cloud.Utilities;
using Domain.Entity;
using Domain.Interface;
using Identity.Shared.Dto;
using System.Threading.Tasks;

namespace Application
{
    public class AuthenticationApp
    {
        private readonly ICacheRepository<User> _cacheUserRepository;
        private readonly IAuthenticationPrincipalService _authenticationService;
        public AuthenticationApp(ICacheRepository<User> cacheUserRepository,
       IAuthenticationPrincipalService authenticationService)
        {
            _cacheUserRepository = cacheUserRepository;
            _authenticationService = authenticationService;
        }

        public User Login(string account, string password) => _cacheUserRepository.FindSingle(u => ((u.Account == account || u.Mobile == account) && u.Password == password && u.Status == 1), u => u.UserRoles);

        public async Task<User> AccountLoginAsync(string account, string password)
        {
            var rsaPassword = EncryptionUtility.MD5(account.StrReverse() + password);
            return await _cacheUserRepository.FindSingleAsync(u => ((u.Account == account || u.Mobile == account) && u.Password == rsaPassword && u.Status == 1), u => u.UserRoles);
        }

        public string SignIn(User user) => _authenticationService.SignIn(user);

        public void SignOut() => _authenticationService.SignOut();

        public async Task<User> GetAuthenticatedUserAsync() => await _authenticationService.GetAuthenticatedUserAsync();

        public async Task<UserListDto> GetAuthUserDtoAsync()
        {
            var entity = await _authenticationService.GetAuthenticatedUserAsync();
            var user = entity.MapTo<UserListDto>();
            if (user == null) throw new MyException("用户不能为空", 0);
            return user;
        }
    }
}
