using BlazorForum.Api.Domain.Models;
using BlazorForum.Common.Infrastructure;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Infrastructure.Persistence.Context
{
    public class SeedData
    {
        private static List<User> GetUsers()
        {
            //Users//
            var result = new Faker<User>("en")
                        .RuleFor(u => u.Id, u => Guid.NewGuid())
                        .RuleFor(u => u.CreatedDate,
                                 u => u.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                        .RuleFor(u => u.FirstName, u => u.Person.FirstName)
                        .RuleFor(u => u.LastName, u => u.Person.LastName)
                        .RuleFor(u => u.EmailAddress, u => u.Internet.Email())
                        .RuleFor(u => u.UserName, u => u.Internet.UserName())
                        .RuleFor(u => u.Password, u => PasswordEncyrptor.Encyrpt(u.Internet.Password()))
                        .RuleFor(u => u.EmailConfirmed, i => i.PickRandom(true, false))
                        .Generate(500);
                      
            return result;  
        }

        public async Task SeedAsync (IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(configuration["BlazorForumConnectionString"]);

            var context = new BlazorForumContext(dbContextBuilder.Options);

            var users = GetUsers();
            var userIds = users.Select(u => u.Id);

            await context.Users.AddRangeAsync(users);

            var guids = Enumerable.Range(0, 150).Select(i => Guid.NewGuid()).ToList();
            int counter = 0;

            //Entries//
            var entries = new Faker<Entry>("en")
                        .RuleFor(i => i.Id, i => guids[counter++])
                        .RuleFor(i => i.CreatedDate,
                                    i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                        .RuleFor(u => u.Subject, u => u.Lorem.Sentence(5, 5))
                        .RuleFor(u => u.Content, u => u.Lorem.Paragraph(2))
                        .RuleFor(u => u.CreatedById, u => u.PickRandom(userIds))
                        .Generate(150);
            await context.Entries.AddRangeAsync(entries);

            //Comments//
            var comments = new Faker<EntryComment>("en")
                        .RuleFor(i => i.Id, i => Guid.NewGuid())
                        .RuleFor(i => i.CreatedDate,
                                      i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                        .RuleFor(i=>i.Content, i=>i.Lorem.Paragraph(2))
                        .RuleFor(i=>i.CreatedById, i=>i.PickRandom(userIds))
                        .RuleFor(i=>i.EntryId, i=>i.PickRandom(guids))
                        .Generate(1000);

            await context.EntryComments.AddRangeAsync(comments);

            await context.SaveChangesAsync();
        }
    }
}
