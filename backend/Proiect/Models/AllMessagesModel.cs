using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class AllMessagesModel
    {
        public string userId { get; set; }
        public int groupId { get; set; }
        public string text { get; set; }
        public DateTime dateAndTime { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
