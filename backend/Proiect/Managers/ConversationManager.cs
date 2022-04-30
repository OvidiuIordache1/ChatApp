using Proiect.Managers;
using Proiect.Repositories;
using Proiect_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Backend.Managers
{
    public class ConversationManager : IConversationManager
    {
        private readonly IUserRepository userRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IMessageDetailRepository messageDetailRepository;
        public ConversationManager(IUserRepository userRepository, IMessageRepository messageRepository, IMessageDetailRepository messageDetailRepository)
        {
            this.userRepository = userRepository;
            this.messageRepository = messageRepository;
            this.messageDetailRepository = messageDetailRepository;
        }
        public List<ConversationModel> GetConversations(int id)
        {
            var lista = new List<ConversationModel>();
            var groups = userRepository.GetUserssWithGroupsAndGroupsName().Where(x => x.userId == id).ToList();
            var mesaje = messageDetailRepository.GetMessageDetailsIQueryable().Where(x => x.DestinatarId == id).Where(y => y.SeenAt == null);
            var nrUnreadMsg = mesaje.GroupBy(x => x.GrupId).Select(x => new
            {
                grId = x.Key,
                count = x.Count()
            }).ToList();

            foreach (var group in groups)
            {
                ConversationModel model = new ConversationModel();
                model.Id = group.userId;
                model.grId = group.groupId;
                model.grName = group.groupName;
                var msg = messageRepository.GetMessagesIQueryable().Where(x => x.GroupId == group.groupId)
                          .OrderByDescending(x => x.DateAndTime).FirstOrDefault();
                if (msg is null)
                {
                    model.lastMessageUserId = -1;
                    model.lastMessageText = "No messages in this group.";
                    model.lastMessageFirstName = "";
                    model.lastMessageLastName = "";
                    model.dateAndTime = DateTime.Now;
                }
                else
                {
                    model.lastMessageUserId = msg.UserId;
                    model.lastMessageText = msg.Text;
                    var name = userRepository.GetUsersInfoIQueryable().FirstOrDefault(x => x.UserId == msg.UserId);
                    model.lastMessageFirstName = name.FirstName;
                    model.lastMessageLastName = name.LastName;
                    model.dateAndTime = msg.DateAndTime;
                }
                model.nrUnreadMsg = 0;
                foreach (var unreadMsg in nrUnreadMsg)
                    if (group.groupId == unreadMsg.grId)
                        model.nrUnreadMsg = unreadMsg.count;
               
                lista.Add(model);
            }

            return lista.OrderByDescending(o => o.dateAndTime).ToList();
        }
    }
}
