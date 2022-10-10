using BlazorForum.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.EntryComment.DeleteVote
{
    public class DeleteEntryCommentVoteCommand : IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }

        public VoteType VoteType { get; set; }

        public Guid DeletedById { get; set; }

        public DeleteEntryCommentVoteCommand(Guid entryCommentId, VoteType voteType, Guid deletedById)
        {
            EntryCommentId = entryCommentId;
            VoteType = voteType;
            DeletedById = deletedById;
        }
    }
}
