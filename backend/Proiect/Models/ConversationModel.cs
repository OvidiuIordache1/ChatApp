using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Backend.Models
{
    public class ConversationModel
    {
        public int Id { get; set; }
        public int grId { get; set; }
        public string grName { get; set; }
        public int lastMessageUserId { get; set; }
        public string lastMessageText { get; set; }
        public string lastMessageFirstName { get; set; }
        public DateTime dateAndTime { get; set; }
        public string lastMessageLastName { get; set; }
        public int nrUnreadMsg { get; set; }
    
    }
}
