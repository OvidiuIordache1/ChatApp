using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppContext db;
        public MessageRepository(AppContext db)
        {
            this.db = db;
        }
        public int Create(Message msg)
        {
            db.Messages.Add(msg);
            db.SaveChanges();
            int id = msg.Id;
            return id;
        }
        public void Update(Message msg)
        {
            db.Messages.Update(msg);
            db.SaveChanges();
        }
        public void Delete(Message msg)
        {
            db.Messages.Remove(msg);
            db.SaveChanges();
        }
        public IQueryable<Message> GetMessagesIQueryable()
        {
            var msg = db.Messages;
            return msg;
        }
        public IQueryable<Message> GetMessagesWithDetails()
        {
            var msg = GetMessagesIQueryable().Include(x => x.MessageDetails);
            return msg;
        }
    }
}
