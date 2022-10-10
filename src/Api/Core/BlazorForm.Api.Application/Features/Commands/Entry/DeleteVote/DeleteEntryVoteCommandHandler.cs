using BlazorForum.Common.Events.Entry;
using BlazorForum.Common.Infrastructure;
using BlazorForum.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.Entry.DeleteVote
{
    public class DeleteEntryVoteCommandHandler : IRequestHandler<DeleteEntryVoteCommand, bool>
    {
        public Task<bool> Handle(DeleteEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: ForumConstants.VoteExchangeName,
                                               exchangeType: ForumConstants.DefaultExchangeType,
                                                queueName: ForumConstants.DeleteEntryVoteQueueName,
                                                obj: new DeleteEntryVoteEvent()
                                                {
                                                    EntryId = request.EntryId.Value,
                                                    DeletedBy = request.UserId.Value
                                                });

            return Task.FromResult(true);
        }
    }
}
