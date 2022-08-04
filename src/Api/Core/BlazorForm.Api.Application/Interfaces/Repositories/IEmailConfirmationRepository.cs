using BlazorForum.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Interfaces.Repositories
{
    public interface IEmailConfirmationRepository : IGenericRepository<EmailConfirmation>
    {
    }
}
