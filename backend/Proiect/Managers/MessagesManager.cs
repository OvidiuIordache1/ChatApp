using Proiect.Entities;
using Proiect.Models;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Managers
{
    public class MessagesManager : IMessagesManager
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IMessageDetailRepository messageDetailRepository;
        public MessagesManager(IMessageRepository messageRepository, IUserRepository userRepository, IGroupRepository groupRepository, IMessageDetailRepository messageDetailRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.messageDetailRepository = messageDetailRepository;
        }

        public List<Message> GetAll()
        {
            return messageRepository.GetMessagesIQueryable().ToList();
        }
        public Message GetMessageById(int id)
        {
            var msg = messageRepository.GetMessagesIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return msg;
        }
        public List<AllMessagesModel> GetMessagesForGroup(int grId)
        {
            var lista = new List<AllMessagesModel>();
            var msgTotal = messageRepository.GetMessagesIQueryable();
            var msg = msgTotal.Where(x => x.GroupId == grId)
                .OrderBy(x => x.DateAndTime).ToList();
            foreach (var mesaj in msg)
            {
                AllMessagesModel model = new AllMessagesModel();
                var name = userRepository.GetUsersInfoIQueryable().FirstOrDefault(x => x.UserId == mesaj.UserId);
                model.userId = mesaj.UserId.ToString();
                model.groupId = grId;
                model.text = mesaj.Text;
                model.dateAndTime = mesaj.DateAndTime;
                model.firstName = name.FirstName;
                model.lastName = name.LastName;
                lista.Add(model);
            }

            return lista;
        }
        public LastMessageModel GetLastMessageForGroup(int grId)
        {
            var msg = messageRepository.GetMessagesIQueryable().Where(x => x.GroupId == grId)
                .OrderByDescending(x => x.DateAndTime).FirstOrDefault();
            if (msg == null)
                return null;
            LastMessageModel last = new LastMessageModel();
            last.userId = msg.UserId;
            last.groupId = msg.GroupId;
            last.text = msg.Text;

            return last;
        }
        public void Create(MessageModel model)
        {
            var newMsg = new Message
            {
                UserId = model.SenderId,
                GroupId = model.GroupId,
                Text = model.Text,
                DateAndTime = DateTime.Now
            };
            int msg_id = messageRepository.Create(newMsg);
            var users = groupRepository.GetGroupsWithUsers().Where(x => x.Id == model.GroupId).ToList()[0].UserGroups;
            foreach (var user in users)
            {
                if (user.UserId != model.SenderId)
                {
                    var msgDetail = new MessageDetail
                    {
                        MessageId = msg_id,
                        DestinatarId = user.UserId,
                        GrupId = model.GroupId,
                        SeenAt = null
                    };
                    messageDetailRepository.Create(msgDetail);
                }
            }
        }
        public void Update(int id, string newText)
        {
            var msg = GetMessageById(id);
            msg.Text = newText;
            messageRepository.Update(msg);
        }
        public void Delete(int id)
        {
            var msg = GetMessageById(id);
            messageRepository.Delete(msg);
        }
    }
}
