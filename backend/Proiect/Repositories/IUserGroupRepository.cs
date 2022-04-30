using Proiect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface IUserGroupRepository
    {
        void Create(UserGroup usergroup);
    }
}
