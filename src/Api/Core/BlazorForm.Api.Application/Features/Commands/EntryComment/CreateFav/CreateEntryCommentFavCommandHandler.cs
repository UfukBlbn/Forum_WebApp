using BlazorForum.Common;
using BlazorForum.Common.Events.EntryComment;
using BlazorForum.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public class CreateEntryCommentFavCommandHandler : IRequestHandler<CreateEntryCommentFavCommand, bool>
    {
        public Task<bool> Handle(CreateEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            //Call to RabbitMq
            QueueFactory.SendMessageToExchange(exchangeName: ForumConstants.FavExchangeName,
                                               exchangeType: ForumConstants.DefaultExchangeType,
                                               queueName: ForumConstants.CreateEntryCommentFavQueueName,
                                               obj: new CreateEntryCommentFavEvent
                                                        {
                                                            CreatedBy = request.UserId,
                                                            EntryCommentId = request.EntryCommentId
                                                        });
            return Task.FromResult(true);   
        }
    }
}
