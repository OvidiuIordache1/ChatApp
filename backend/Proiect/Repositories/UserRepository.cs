using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppContext db;
        public UserRepository(AppContext db)
        {
            this.db = db;
        }
        public void Create(UserInfo user)
        {
            db.UserInform.Add(user);
            db.SaveChanges();
        }
        public void Update(UserInfo user)
        {
            db.UserInform.Update(user);
            db.SaveChanges();
        }
        public void Delete(UserInfo user)
        {
            db.UserInform.Remove(user);
            db.SaveChanges();
        }
        public IQueryable<UserInfo> GetUsersInfoIQueryable()
        {
            var users = db.UserInform;
            return users;
        }
        public IQueryable<User> GetUsersIQueryable()
        {
            var users = db.Users;
            return users;
        }
        public IQueryable<User> GetUsersWithGroups()
        {
            var users = GetUsersIQueryable().Include(x => x.UserGroups);
            return users;
        }
        public IQueryable<User> GetUsersWithMessages()
        {
            var users = GetUsersIQueryable().Include(x => x.Messages);
            return users;
        }
        public IQueryable<JoinUserModel> GetUserssWithGroupsAndGroupsName()
        {
            var groups = db.Groups.Join(db.UserGroups, gr => gr.Id, uig => uig.GroupId, (gr, uig) => new { gr, uig })
                                  .Select(m => new JoinUserModel
                                  {
                                      userId = m.uig.UserId,
                                      groupId = m.gr.Id,
                                      groupName = m.gr.Name
                                  });
            return groups;
        }
    }
}
