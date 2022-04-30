using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; } // sender - user
        public int GroupId { get; set; } // receiver - grup
        public string Text { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<MessageDetail> MessageDetails { get; set; }
    }
}
