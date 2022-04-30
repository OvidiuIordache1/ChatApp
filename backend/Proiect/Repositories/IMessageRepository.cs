using Proiect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface IMessageRepository
    {
        int Create(Message msg);
        void Update(Message msg);
        void Delete(Message msg);
        IQueryable<Message> GetMessagesIQueryable();
        IQueryable<Message> GetMessagesWithDetails();
    }
}
