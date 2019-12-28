using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SharedAll.Models;
using SharedAll.Models.Result;

namespace Back.MiddleTier.Interface
{
    public interface ILoginServices
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<SignInResult> Login(LoginViewModel model);
    }
}
