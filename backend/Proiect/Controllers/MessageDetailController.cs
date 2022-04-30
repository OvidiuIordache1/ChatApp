using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Entities;
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
    public class MessageDetailController : ControllerBase
    {
        private readonly IMessageDetailsManager manager;
        public MessageDetailController(IMessageDetailsManager messageDetailsManager)
        {
            this.manager = messageDetailsManager;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> Getall()
        {
            var messages = manager.GetAll();
            return Ok(messages);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var messages = manager.GetMessageDetailById(id);
            return Ok(messages);
        }
        [HttpGet("get-nr-of-unread-messages/{id}")]
        // [Authorize("Admin")]
        public async Task<IActionResult> GetNrOfUnreadMessages([FromRoute] int id)
        {
            var messages = manager.GetNrOfUnreadMsg(id);
            return Ok(messages);
        }
        [HttpPost("create-message-detail")]

        public async Task<IActionResult> Create([FromBody] MessageDetail messageModel)
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

        [HttpPut("update-message-detail")]
        public async Task<IActionResult> Update([FromBody] MessageDetailModel model)
        {
            manager.UpdateDetails(model);
            return Ok();
        }
    }
}
