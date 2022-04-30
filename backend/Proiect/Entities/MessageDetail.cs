using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class MessageDetail
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int DestinatarId { get; set; }
        public int GrupId { get; set; }
        public DateTime? SeenAt { get; set; } = null; // data la care a fost vazut / null daca msg. nu a fost vazut

        public virtual Message Message { get; set; }

    }
}
