using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Managers
{
    public interface IUsersInfoManager
    {
        List<User> GetAll();
        UserInfoModel GetUserById(int id);
        List<User> GetGroupsForUser(int id);
        List<string> GetNames(int id);
        List<JoinUserModel> GetGroupsAndNamesForUser(int id);
        List<User> GetMessagesForUser(int id);
        void Create(UserInfoModel model);
        void Update(UserInfoModel model);
        void Delete(int id);
    }
}
