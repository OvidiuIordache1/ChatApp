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
    public class GroupController : ControllerBase
    {
        private readonly IGroupsManager manager;
        public GroupController(IGroupsManager groupsManager)
        {
            this.manager = groupsManager;
        }

        [HttpGet("get-all")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Getall()
        {
            var groups = manager.GetAll(); 
            return Ok(groups);
        }

        [HttpGet("get-by-id/{id}")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var groups = manager.GetGroupById(id);
            return Ok(groups);
        }
        
        [HttpGet("get-group-info/{id}")]
        public async Task<IActionResult> GetGroupInfo([FromRoute] int id)
        {
            var groups = manager.GetGroupInfo(id);
            return Ok(groups);
        }

        [HttpGet("get-users-for-group/{id}")]
        public async Task<IActionResult> GetUsersGroup([FromRoute] int id)
        {
            var groups = manager.GetUsersForGroup(id);
            return Ok(groups);
        }
        [HttpGet("get-users-and-names-for-group/{id}")]
        public async Task<IActionResult> GetUsersNamesGroup([FromRoute] int id)
        {
            var groups = manager.GetUsersAndNamesForGroup(id);
            return Ok(groups);
        }

        [HttpPost("create-group")]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            manager.Create(name);
            return Ok();
        }

        [HttpPost("create-group-with-user/{name}/{id}")]
        public async Task<IActionResult> CreateGroupWithUser([FromRoute] string name, int id)
        {
            manager.CreateGroupWithUser(name, id);
            return Ok();
        }
        [HttpPost("add-user-with-code/{code}/{id}")]
        public async Task<IActionResult> AddUserWithCode([FromRoute] string code, int id)
        {
            manager.AddUserWithCode(code, id);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpPut("update-grup/{id}/{newName}")]
        public async Task<IActionResult> Update([FromRoute] int id, string newName)
        {
            manager.Update(id, newName);
            return Ok();
        }
    }
}
