using AutoMapper;
using IdentityUserLogin.Core.Domain.IdentityEntities;
using IdentityUserLogin.Core.Mappings;
using IdentityUserLogin.Core.Services.UserService;
using IdentityUserLogin.Core.Services.UserService.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityUserLogin.Core
{
    public static class CoreServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<UserMappingProfile>();
            });

            services.AddSingleton(mappingConfig.CreateMapper());
            services.AddTransient<IUserAdderService,UserAdderService>();
        }
    }
}
