using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface IMessageDetailRepository
    {
        void Create(MessageDetail msg);
        void Update(MessageDetailModel msgDetail);
        void Delete(MessageDetail msg);
        IQueryable<MessageDetail> GetMessageDetailsIQueryable();
    }
}
