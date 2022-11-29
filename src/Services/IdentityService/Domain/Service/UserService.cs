
using Cloud.Caching;
using Cloud.EventBus;
using Cloud.Models;
using Cloud.Repositories;
using Cloud.Repositories.EntityFrameworkCore;
using Cloud.Snowflake;
using Domain.Entity;
using Domain.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IEfCoreUnitWork _unitWork;
        private readonly ISnowflakeIdWorker _snowflakeIdWorker;
        private readonly IAuthenticationPrincipalService _authenticationService;
        private readonly ICache _cache;
        private readonly ICacheRepository<User> _cacheUserRepository;
        private readonly IMQPublish _mqPublish;
        public UserService(IEfCoreUnitWork unitWork, ISnowflakeIdWorker snowflakeIdWorker, IAuthenticationPrincipalService authenticationService, ICache cache, ICacheRepository<User> listCacheUserRepository, IMQPublish mqPublish)
        {
            _unitWork = unitWork;
            _snowflakeIdWorker = snowflakeIdWorker;
            _authenticationService = authenticationService;
            _cache = cache;
            _cacheUserRepository = listCacheUserRepository;
            _mqPublish = mqPublish;
        }

        public bool IsMobileExist(string mobile, long id = 0)
        {
            if (id == default)
            {
                return _unitWork.IsExist<User>(u => u.Mobile == mobile);
            }
            else
            {
                return _unitWork.IsExist<User>(u => u.Mobile == mobile && u.Id != id);
            }
        }

        public User GetUserBythirdpartId(string thirdpartId)
        {
            return _unitWork.FindSingle<User>(u => u.ThirdpartId == thirdpartId, u => u.UserRoles);
        }

        public async Task<User> AddAsync(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.ThirdpartId) && null != GetUserBythirdpartId(user.ThirdpartId))
            {
                return user;
            }
            if(!string.IsNullOrWhiteSpace(user.Mobile)) user.Mobile=user.Mobile.Trim();
            if (!string.IsNullOrWhiteSpace(user.Account)) user.Account = user.Account.Trim();
            user.CreateDate = DateTime.Now;
            user.Id = _unitWork.GetNextId();
            if (user.UserRoles != null && user.UserRoles.Count > 0)
            {
                user.UserRoles.ToList().ForEach(item =>
                {
                    item.Id = _unitWork.GetNextId();
                    item.UserId = user.Id;
                    _unitWork.Add(item);
                });
            }
            user = _unitWork.Add<User>(user);

            _unitWork.Commit();
            _unitWork.OnSetted<User>(user);
            _unitWork.RemoveListCache<Role>();
            return user;
        }
        public virtual void Update(User user)
        {
            _unitWork.Delete<UserRole>((Expression<Func<UserRole, bool>>)(r => r.UserId == user.Id));
            if (user.UserRoles != null && user.UserRoles.Count() > 0)
            {
                user.UserRoles.ToList().ForEach(item =>
                {
                    item.Id = _unitWork.GetNextId();
                    item.UserId = user.Id;
                    _unitWork.Add(item);
                });
            }
           if(!string.IsNullOrWhiteSpace(user.Mobile))  user.Mobile = user.Mobile.Trim();
            _unitWork.Update<User>(user);
            _unitWork.Commit();
            _unitWork.OnSetted<User>(user);
            _unitWork.RemoveListCache<Role>();
        }

        public async Task ResetPasswordAsync(long id)
        {
            if (id == default) throw new MyException("用户id不能为空！", 0);
            var user = await _unitWork.FindSingleAsync<User>(x => x.Id == id && x.Status == 1, u => u.UserRoles);
            await _unitWork.UpdateAsync<User>(user);
            _unitWork.Commit();
            await _unitWork.OnSettedAsync<User>(user);
        }

    }

}
