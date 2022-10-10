using BlazorForum.Common;
using BlazorForum.Common.Events.EntryComment;
using BlazorForum.Common.Infrastructure;
using MediatR;

namespace BlazorForm.Api.Application.Features.Commands.EntryComment.DeleteVote
{
    public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {


            QueueFactory.SendMessageToExchange(exchangeName: ForumConstants.VoteExchangeName,
                                                exchangeType: ForumConstants.DefaultExchangeType,
                                                queueName: ForumConstants.DeleteEntryCommentVoteQueueName,
                                                obj: new DeleteEntryCommentVoteEvent()
                                                {
                                                    DeletedById = request.DeletedById,
                                                    EntryCommentId = request.EntryCommentId
                                                });



            return await Task.FromResult(true);

        }
    }
}
