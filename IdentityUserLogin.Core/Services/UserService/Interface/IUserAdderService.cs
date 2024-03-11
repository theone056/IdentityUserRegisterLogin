using IdentityUserLogin.Core.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityUserLogin.Core.Services.UserService.Interface
{
    public interface IUserAdderService
    {
        Task<IdentityResult> CreateUser(UserRegistrationModel registrationModel);
    }
}
