using Proiect.Entities;
using Proiect.Models;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Managers
{
    public class UsersInfoManager : IUsersInfoManager
    {
        private readonly IUserRepository userRepository;
        public UsersInfoManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return userRepository.GetUsersIQueryable().ToList();
        }
        public UserInfoModel GetUserById(int id)
        {
            var user = userRepository.GetUsersInfoIQueryable()
                .FirstOrDefault(x => x.UserId == id);
            var userInfo = new UserInfoModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id
            };
            return userInfo;
        }
        public List<string> GetNames(int id)
        {
            var list = new List<string>();
            var names = userRepository.GetUsersInfoIQueryable().Where(x => x.UserId == id).ToList()[0];
            list.Add(names.FirstName);
            list.Add(names.LastName);
            return list;
        }

        public List<User> GetGroupsForUser(int id)
        {
            var groups = userRepository.GetUsersWithGroups().Where(x => x.Id == id).ToList();
            return groups;
        }
        public List<JoinUserModel> GetGroupsAndNamesForUser(int id)
        {
            var groups = userRepository.GetUserssWithGroupsAndGroupsName().Where(x => x.userId == id).ToList();
            return groups;
        }
        public List<User> GetMessagesForUser(int id)
        {
            var msg = userRepository.GetUsersWithMessages().Where(x => x.Id == id).ToList();
            return msg;
        }

        public void Create(UserInfoModel model)
        {
            var newUserInfo = new UserInfo
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = model.Id
            };
            userRepository.Create(newUserInfo);
        }
        public void Update(UserInfoModel model)
        {
            var user = userRepository.GetUsersInfoIQueryable()
                .FirstOrDefault(x => x.Id == model.Id);
            if (model.FirstName != "")
            {
                user.FirstName = model.FirstName;
            }
            if (model.LastName != "")
            {
                user.LastName = model.LastName;
            }
            userRepository.Update(user);
        }
        public void Delete(int id)
        {
            var user = userRepository.GetUsersInfoIQueryable()
                .FirstOrDefault(x => x.Id == id);
            userRepository.Delete(user);
        }
    }
}
