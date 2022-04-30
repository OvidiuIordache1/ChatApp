using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Models;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Managers
{
    public class GroupsManager : IGroupsManager
    {
        private readonly IGroupRepository groupRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private static Random random = new Random();
        public GroupsManager(IGroupRepository groupRepository, IUserGroupRepository userGroupRepository)
        {
            this.groupRepository = groupRepository;
            this.userGroupRepository = userGroupRepository;
        }

        public List<Group> GetAll()
        {
            return groupRepository.GetGroupsIQueryable().ToList();
        }
        public Group GetGroupById(int id)
        {
            var group = groupRepository.GetGroupsIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return group;
        }
        public List<string> GetGroupsInviteCodes()
        {
            var inviteCodes = groupRepository.GetGroupsIQueryable()
                .Select(x => x.InviteCode)
                .ToList();
            return inviteCodes;
        }
        private string createRandom()
        {
            var chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        public void Create(String name)
        {
            var inviteCodes = GetGroupsInviteCodes();
            var result = createRandom();
            while (inviteCodes.Contains(result))
            {
                result = createRandom();
            }

            var newGroup = new Group
            {
                Name = name,
                InviteCode = result
            };
            groupRepository.Create(newGroup);
        }

        public void CreateGroupWithUser(string name, int id)
        {
            var inviteCodes = GetGroupsInviteCodes();
            var result = createRandom();
            while (inviteCodes.Contains(result))
            {
                result = createRandom();
            }

            var newGroup = new Group
            {
                Name = name,
                InviteCode = result
            };
            groupRepository.Create(newGroup);
            var grId = groupRepository.GetGroupsIQueryable().FirstOrDefault(x => x.InviteCode == result);
            var userGroup = new UserGroup
            {
                UserId = id,
                GroupId = grId.Id,
                Role = 1
            };
            userGroupRepository.Create(userGroup);
        }
        public void AddUserWithCode(string code, int id)
        {
            var grId = groupRepository.GetGroupsIQueryable().FirstOrDefault(x => x.InviteCode == code);
            var userGroup = new UserGroup
            {
                UserId = id,
                GroupId = grId.Id,
                Role = 0
            };
            userGroupRepository.Create(userGroup);
        }

        public void Delete(int id)
        {
            var group = GetGroupById(id);
            groupRepository.Delete(group);
        }
        public void Update(int id, string NewName)
        {
            var group = GetGroupById(id);
            group.Name = NewName;
            groupRepository.Update(group);
        }
        public Group GetGroupInfo(int id)
        {
            var inviteCodes = groupRepository.GetGroupsIQueryable()
                .Where(x => x.Id == id)
                .ToList();
            return inviteCodes[0];
        }
        public List<Group> GetUsersForGroup(int id)
        {
            var users = groupRepository.GetGroupsWithUsers().Where(x => x.Id == id).ToList();
            return users;
        }

        public List<JoinGroupModel> GetUsersAndNamesForGroup(int id)
        {
            var users = groupRepository.GetGroupsWithUsersAndUsersName().Where(x => x.groupId == id).ToList();
            return users;
        }
    }
}
