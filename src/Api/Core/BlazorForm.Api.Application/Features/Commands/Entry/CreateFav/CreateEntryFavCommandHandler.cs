using BlazorForum.Common;
using BlazorForum.Common.Events.Entry;
using BlazorForum.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommandHandler : IRequestHandler<CreateEnrtyFavCommand, bool>
    {
        public Task<bool> Handle(CreateEnrtyFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: ForumConstants.FavExchangeName,
                                               exchangeType:ForumConstants.DefaultExchangeType,
                                                queueName: ForumConstants.CreateEntryCommentFavQueueName,
                                                obj: new CreateEntryFavEvent()
                                                {
                                                    EntryId = request.EntryId.Value,
                                                    CreatedBy = request.UserId.Value
                                                });

            return Task.FromResult(true);
        }
    }
}
