using BlazorForum.Common;
using BlazorForum.Common.Events.Entry;
using BlazorForum.Common.Infrastructure;
using BlazorForum.Common.Models.RequestModels;
using MediatR;

namespace BlazorForm.Api.Application.Features.Commands.Entry.CreateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: ForumConstants.VoteExchangeName,
                                                exchangeType: ForumConstants.DefaultExchangeType,
                                                queueName: ForumConstants.CreateEntryVoteQueueName,
                                                obj: new CreateEntryVoteEvent()
                                                {
                                                    EntryId = request.EntryId,
                                                    CreatedBy = request.CreatedById,
                                                    VoteType = request.VoteType

                                                });

            return await Task.FromResult(true);

        }
    }
}
