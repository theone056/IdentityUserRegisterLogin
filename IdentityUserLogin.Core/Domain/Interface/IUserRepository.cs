using IdentityUserLogin.Core.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityUserLogin.Core.Domain.Interface
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUser(UserRegistrationModel registerModel);
        Task<bool> LoginUser(UserLoginModel loginModel);
    }
}
