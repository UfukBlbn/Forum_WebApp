using BlazorForum.Common.Events.EntryComment;
using BlazorForum.Common.Infrastructure;
using BlazorForum.Common;
using MediatR;

namespace BlazorForm.Api.Application.Features.Commands.EntryComment.DeleteFav
{
    public class DeleteEntryCommentFavCommandHandler : IRequestHandler<DeleteEntryCommentFavCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(queueName: ForumConstants.DeleteEntryCommentFavQueueName,
                                            exchangeName: ForumConstants.VoteExchangeName,
                                            exchangeType: ForumConstants.DefaultExchangeType,
                                            obj: new DeleteEntryCommentFavEvent()
                                            {
                                                DeletedById = request.DeletedBy,
                                                EntryCommentId = request.EntryCommentId,
                                            });

            return await Task.FromResult(true);
        }
    }

}
