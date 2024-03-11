using AutoMapper;
using IdentityUserLogin.Core.Domain.IdentityEntities;
using IdentityUserLogin.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityUserLogin.Core.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() { 
            CreateMap<ApplicationUser, UserRegistrationModel>().ReverseMap();
        }
    }
}
