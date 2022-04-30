using Proiect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proiect.Interfaces
{
    public interface ITokenManager
    {
        Task<string> CreateAccessToken(User user);
        string CreateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token);
    }
}
