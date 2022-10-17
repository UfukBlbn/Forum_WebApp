using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Api.Domain.Models;
using BlazorForum.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Infrastructure.Persistence.Repositories
{
    public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(BlazorForumContext dbContext) : base(dbContext)
        {
        }
    }
}
