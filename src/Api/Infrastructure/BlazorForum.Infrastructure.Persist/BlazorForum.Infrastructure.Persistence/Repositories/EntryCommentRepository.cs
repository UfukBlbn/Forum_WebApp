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
    public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
    {
        public EntryCommentRepository(BlazorForumContext dbContext) : base(dbContext)
        {
        }
    }
}
