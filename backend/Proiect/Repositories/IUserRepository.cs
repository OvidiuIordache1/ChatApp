using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface IUserRepository
    {
        void Create(UserInfo user);
        void Update(UserInfo user);
        void Delete(UserInfo user);
        IQueryable<User> GetUsersIQueryable();
        IQueryable<UserInfo> GetUsersInfoIQueryable();
        IQueryable<User> GetUsersWithGroups();
        IQueryable<JoinUserModel> GetUserssWithGroupsAndGroupsName();
        IQueryable<User> GetUsersWithMessages();
    }
}
