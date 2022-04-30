using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Managers
{
    public interface IMessageDetailsManager
    {
        List<MessageDetail> GetAll();
        List<UserDetailsModel> GetNrOfUnreadMsg(int userId);
        MessageDetail GetMessageDetailById(int id);
        void Create(MessageDetail newMsgDetail);
        void UpdateDetails(MessageDetailModel model);
        void Delete(int id);
    }
}
