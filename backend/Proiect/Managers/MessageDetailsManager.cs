using Proiect.Entities;
using Proiect.Models;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Managers
{
    public class MessageDetailsManager : IMessageDetailsManager
    {
        private readonly IMessageDetailRepository messageDetailRepository;
        public MessageDetailsManager(IMessageDetailRepository messageDetailRepository)
        {
            this.messageDetailRepository = messageDetailRepository;
        }
        public List<MessageDetail> GetAll()
        {
            return messageDetailRepository.GetMessageDetailsIQueryable().ToList();
        }
        public List<UserDetailsModel> GetNrOfUnreadMsg(int userId)
        {
            var lista = new List<UserDetailsModel>();
            var msg = messageDetailRepository.GetMessageDetailsIQueryable().Where(x => x.DestinatarId == userId).Where(y => y.SeenAt == null);
            var unreadMsg = msg.GroupBy(x => x.GrupId).Select(x => new
            {
                grId = x.Key,
                count = x.Count()
            }).ToList();
            foreach (var mesaj in unreadMsg)
            {
                UserDetailsModel info = new UserDetailsModel();
                info.grId = mesaj.grId;
                info.count = mesaj.count;
                lista.Add(info);
            }
            return lista;
        }
        public MessageDetail GetMessageDetailById(int id)
        {
            var msg = messageDetailRepository.GetMessageDetailsIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return msg;
        }
        public void Create(MessageDetail newMsgDetail)
        {
            messageDetailRepository.Create(newMsgDetail);
        }
        public void UpdateDetails(MessageDetailModel model)
        {
            messageDetailRepository.Update(model);
        }
        public void Delete(int id)
        {
            var msg = GetMessageDetailById(id);
            messageDetailRepository.Delete(msg);
        }
    }
}
