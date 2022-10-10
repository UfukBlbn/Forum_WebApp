using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEnrtyFavCommand : IRequest<bool>
    {
        public Guid? EntryId { get; set; }
        public Guid? UserId { get; set; }
        public CreateEnrtyFavCommand()
        {

        }
        public CreateEnrtyFavCommand(Guid? entryId, Guid? userId)
        {
            EntryId = entryId;
            UserId = userId;
        }

       
    }
}
