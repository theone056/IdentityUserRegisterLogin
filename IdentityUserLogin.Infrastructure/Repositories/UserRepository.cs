using AutoMapper;
using IdentityUserLogin.Core.Domain.IdentityEntities;
using IdentityUserLogin.Core.Domain.Interface;
using IdentityUserLogin.Core.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityUserLogin.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public UserRepository(UserManager<ApplicationUser> userManager, 
                              SignInManager<ApplicationUser> signInManager,   
                              IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<IdentityResult> CreateUser(UserRegistrationModel registerModel)
        {
            try
            {
                var mapRegModel = _mapper.Map<ApplicationUser>(registerModel);
                return await _userManager.CreateAsync(mapRegModel, registerModel.Password); ;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> LoginUser(UserLoginModel loginModel)
        {
            if(loginModel == null) throw new ArgumentNullException( nameof(loginModel));
            try
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Username);
                if (user == null) return false;
                return await _userManager.CheckPasswordAsync(user,loginModel.Password);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
