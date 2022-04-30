using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InviteCode { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
