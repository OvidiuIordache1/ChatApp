using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Managers
{
    public interface IGroupsManager
    {
        List<Group> GetAll();
        Group GetGroupById(int id);
        Group GetGroupInfo(int id);
        List<string> GetGroupsInviteCodes();
        List<Group> GetUsersForGroup(int id);
        List<JoinGroupModel> GetUsersAndNamesForGroup(int id);
        void Create(string name);
        void CreateGroupWithUser(string name, int id);
        void AddUserWithCode(string code, int id);
        void Update(int id, string NewName);
        void Delete(int id);
    }
}
