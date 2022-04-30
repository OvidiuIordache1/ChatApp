using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Managers;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessagesManager manager;
        public MessageController(IMessagesManager messagesManager)
        {
            this.manager = messagesManager;
        }
        [HttpGet("get-all")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Getall()
        {
            var messages = manager.GetAll();
            return Ok(messages);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var messages = manager.GetMessageById(id);
            return Ok(messages);
        }

        [HttpGet("get-messages-for-group/{grId}")]
        public async Task<IActionResult> GetMessagesGroup([FromRoute] int grId)
        {
            var messages = manager.GetMessagesForGroup(grId);
            return Ok(messages);
        }

        [HttpGet("get-last-message-for-group/{grId}")]
        public async Task<IActionResult> GetLasMessageGroup([FromRoute] int grId)
        {
            var message = manager.GetLastMessageForGroup(grId);
            return Ok(message);
        }

        [HttpPost("create-message")]
        public async Task<IActionResult> Create([FromBody] MessageModel messageModel)
        {
            manager.Create(messageModel);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpPut("update-message/{id}/{newText}")]
        public async Task<IActionResult> Update([FromRoute] int id, string newText)
        {
            manager.Update(id, newText);
            return Ok();
        }
    }
}
