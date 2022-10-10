using BlazorForum.Common.Events.Entry;
using BlazorForum.Common.Infrastructure;
using BlazorForum.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.Entry.DeleteFav
{
    public class DeleteEntryCommandHandler : IRequestHandler<DeleteEntryFavCommand, bool>
    {
        public Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
        {

            QueueFactory.SendMessageToExchange(exchangeName: ForumConstants.FavExchangeName,
                                          exchangeType: ForumConstants.DefaultExchangeType,
                                           queueName: ForumConstants.DeleteEntryFavQueueName,
                                           obj: new DeleteEntryFavEvent()
                                           {
                                               EntryId = request.EntryId.Value,
                                               DeletedBy = request.UserId.Value
                                           });

            return Task.FromResult(true);

        }
    }
}
