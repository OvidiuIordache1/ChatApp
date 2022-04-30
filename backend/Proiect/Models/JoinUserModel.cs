using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class JoinUserModel
    {
        public int userId { get; set; }
        public int groupId { get; set; }
        public string groupName { get; set; }
    }
}
