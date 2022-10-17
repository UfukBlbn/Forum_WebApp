
using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Infrastructure.Persistence.Context;
using BlazorForum.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BlazorForumContext>(conf =>
            {
                var connStr = configuration["BlazorForumConnectionString"].ToString();
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            //var seedData = new SeedData();
            //seedData.SeedAsync(configuration).GetAwaiter().GetResult();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
            services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
 


            return services;
        }
    }

}
