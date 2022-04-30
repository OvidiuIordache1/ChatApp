using Microsoft.AspNetCore.Identity;
using Proiect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void CreateRoles()
        {
            string[] roleNames = {
                                "Admin",
                                "User"
                                };

            foreach (var roleName in roleNames)
            {
                var role = new Role
                {
                    Name = roleName
                };
                _roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
