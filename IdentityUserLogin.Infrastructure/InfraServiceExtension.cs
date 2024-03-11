using IdentityUserLogin.Core.Domain.IdentityEntities;
using IdentityUserLogin.Core.Domain.Interface;
using IdentityUserLogin.Infrastructure.Context;
using IdentityUserLogin.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityUserLogin.Infrastructure
{
    public static class InfraServiceExtension
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("connectionString"));
            });

            services.AddIdentity<ApplicationUser, ApplicationUserRole>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = false;
            })
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
                  /*  .AddUserStore<UserStore<ApplicationUser,ApplicationUserRole,ApplicationDbContext,Guid>>()
                    .AddRoleStore<RoleStore<ApplicationUserRole, ApplicationDbContext, Guid>>();*/
           services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
