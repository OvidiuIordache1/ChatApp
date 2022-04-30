using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppContext db;
        public GroupRepository (AppContext db)
        {
            this.db = db;
        }

        public void Create(Group group)
        {
            db.Groups.Add(group);
            db.SaveChanges();
        }
        public void Update(Group group)
        {
            db.Groups.Update(group);
            db.SaveChanges();
        }
        public void Delete(Group group)
        {
            db.Groups.Remove(group);
            db.SaveChanges();
        }
        public IQueryable<Group> GetGroupsIQueryable()
        {
            var groups = db.Groups;
            return groups;
        }
        public IQueryable<Group> GetGroupsWithUsers()
        {
            var groups = GetGroupsIQueryable().Include(x => x.UserGroups);
            return groups;
        }
        public IQueryable<JoinGroupModel> GetGroupsWithUsersAndUsersName()
        {
            var groups = db.Groups.Join(db.UserGroups, gr => gr.Id, uig => uig.GroupId, (gr, uig) => new { gr, uig })
                                  .Join(db.UserInform, x => x.uig.UserId, ui => ui.Id, (x, ui) => new { x, ui })
                                  .Select(m => new JoinGroupModel 
                                  { 
                                    groupId = m.x.uig.GroupId,
                                    userId = m.ui.Id,
                                    FirstName = m.ui.FirstName,
                                    LastName = m.ui.LastName
                                  });
            return groups;
        }
    }
}
