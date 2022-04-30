using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Proiect.Entities
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
