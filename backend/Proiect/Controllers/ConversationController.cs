using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Backend.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationManager manager;
        public ConversationController(IConversationManager conversationManager)
        {
            this.manager = conversationManager;
        }

        [HttpGet("get-conversations/{id}")]
        // [Authorize(Policy = "User")]
        public async Task<IActionResult> GetConversations([FromRoute] int id)
        {
            var conversations = manager.GetConversations(id);
            return Ok(conversations);
        }
    }
}
