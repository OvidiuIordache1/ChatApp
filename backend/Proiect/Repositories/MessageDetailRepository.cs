using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class MessageDetailRepository : IMessageDetailRepository
    {
        private readonly AppContext db;
        public MessageDetailRepository(AppContext db)
        {
            this.db = db;
        }
        public void Create(MessageDetail msg)
        {
            db.MessageDetails.Add(msg);
            db.SaveChanges();
        }
        public void Update(MessageDetailModel msgDetail)
        {
            var messages = db.MessageDetails.Where(x => x.GrupId == msgDetail.grId && x.DestinatarId == msgDetail.dstId && x.SeenAt == null).ToList();
            foreach (var msg in messages)
            {
                msg.SeenAt = msgDetail.dateAndTime;
                db.MessageDetails.Update(msg);
                db.SaveChanges();
            }
        }
        public void Delete(MessageDetail msg)
        {
            db.MessageDetails.Remove(msg);
            db.SaveChanges();
        }
        public IQueryable<MessageDetail> GetMessageDetailsIQueryable()
        {
            var msg = db.MessageDetails;
            return msg;
        }
    }
}
