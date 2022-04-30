using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Managers
{
    public interface IMessagesManager
    {
        List<Message> GetAll();
        Message GetMessageById(int id);
        List<AllMessagesModel> GetMessagesForGroup(int grId);
        LastMessageModel GetLastMessageForGroup(int grId);
        void Create(MessageModel model);
        void Update(int id, string newText);
        void Delete(int id);
    }
}
