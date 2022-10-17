using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public Guid ConfitmationId { get; set; }

    }
}
