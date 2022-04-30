using Proiect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly AppContext db;
        public UserGroupRepository(AppContext db)
        {
            this.db = db;
        }
        public void Create(UserGroup userGroup)
        {
            db.UserGroups.Add(userGroup);
            db.SaveChanges();
        }
    }
}
