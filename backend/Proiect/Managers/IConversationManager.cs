using Proiect_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Backend.Managers
{
    public interface IConversationManager
    {
        List<ConversationModel> GetConversations(int id);
    }
}
