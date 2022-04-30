using Proiect.Entities;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Interfaces
{
    public interface IAuthManager
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task<int> Register(RegisterModel registerModel);
        Task<string> Refresh(RefreshModel refreshModel);
    }
}
