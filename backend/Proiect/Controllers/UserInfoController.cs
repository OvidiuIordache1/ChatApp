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
    public class UserInfoController : ControllerBase
    {
        private readonly IUsersInfoManager manager;
        public UserInfoController(IUsersInfoManager usersManager)
        {
            this.manager = usersManager;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> Getall()
        {
            var users = manager.GetAll();
            return Ok(users);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var users = manager.GetUserById(id);
            return Ok(users);
        }
        [HttpGet("get-groups-for-user/{id}")]
        public async Task<IActionResult> GetGroupsUser([FromRoute] int id)
        {
            var users = manager.GetGroupsForUser(id);
            return Ok(users);
        }
        [HttpGet("get-groups-and-group-names-for-user/{id}")]
        public async Task<IActionResult> GetGroupsNamesUser([FromRoute] int id)
        {
            var users = manager.GetGroupsAndNamesForUser(id);
            return Ok(users);
        }
        [HttpGet("get-messages-for-user/{id}")]
        public async Task<IActionResult> GetUsersMessages([FromRoute] int id)
        {
            var users = manager.GetMessagesForUser(id);
            return Ok(users);
        }
        [HttpGet("get-names/{id}")]
        public async Task<IActionResult> GetNames([FromRoute] int id)
        {
            var users = manager.GetNames(id);
            return Ok(users);
        }
        [HttpPost("create-user-info")]
        public async Task<IActionResult> Create([FromBody] UserInfoModel userModel)
        {
            manager.Create(userModel);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> Update([FromBody] UserInfoModel userModel)
        {
            manager.Update(userModel);
            return Ok();
        }
    }
}
