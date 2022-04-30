using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class UserMessage
    {
        public string senderId { get; set; }
        public string groupId { get; set; }
        public string text { get; set; }
    }
}
