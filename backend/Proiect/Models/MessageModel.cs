using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class MessageModel
    {
        public int SenderId { get; set; }
        public int GroupId { get; set; }
        public string Text { get; set; }
    }
}
