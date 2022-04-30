using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class User : IdentityUser<int>
    {
        public string RefreshToken { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}