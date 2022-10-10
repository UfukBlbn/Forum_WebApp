using BlazorForum.Common;
using BlazorForum.Common.Events.EntryComment;
using BlazorForum.Common.Infrastructure;
using BlazorForum.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.EntryComment.CreateVote
{
    public class CreateEntryCommentVoteCommandHandler : IRequestHandler<CreateEntryCommentVoteCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(queueName: ForumConstants.CreateEntryCommentVoteQueueName,
                                                exchangeName: ForumConstants.VoteExchangeName,
                                                exchangeType: ForumConstants.DefaultExchangeType,
                                                obj: new CreateEntryCommentVoteEvent()
                                                {
                                                    CreatedBy = request.CreatedBy,
                                                    EntryCommentId = request.EntryCommnetId,
                                                    VoteType = request.VoteType
                                                });

            return await Task.FromResult(true);
        }
    }
}
