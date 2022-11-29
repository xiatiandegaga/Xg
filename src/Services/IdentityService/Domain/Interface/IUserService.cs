using Domain.Entity;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserService
    {
        bool IsMobileExist(string mobile, long id = 0);
        Task<User> AddAsync(User user);
        void Update(User user);
    }
}
