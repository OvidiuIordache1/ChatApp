using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface IGroupRepository
    {
        void Create(Group group);
        void Update(Group group);
        void Delete(Group group);
        IQueryable<Group> GetGroupsIQueryable();
        IQueryable<Group> GetGroupsWithUsers();
        IQueryable<JoinGroupModel> GetGroupsWithUsersAndUsersName();
    }
}
