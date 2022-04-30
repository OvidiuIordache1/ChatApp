using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int Role { get; set; } // 1 - Admin, 0 - User

        public virtual User User {get; set;}
        public virtual Group Group { get; set; }
    }
}
