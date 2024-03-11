using IdentityUserLogin.Core.Domain.Interface;
using IdentityUserLogin.Core.DTO;
using IdentityUserLogin.Core.Services.UserService.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityUserLogin.Core.Services.UserService
{
    public class UserAdderService : IUserAdderService
    {
        private readonly IUserRepository _userRepository;
        public UserAdderService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IdentityResult> CreateUser(UserRegistrationModel registrationModel)
        {
            if (registrationModel == null) throw new ArgumentNullException(nameof(registrationModel));

            try
            {
                return await _userRepository.CreateUser(registrationModel);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
