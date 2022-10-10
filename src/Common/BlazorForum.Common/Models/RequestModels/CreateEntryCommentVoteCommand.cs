using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Common.Models.RequestModels
{
    public class CreateEntryCommentVoteCommand : IRequest<bool>
    {
        public Guid EntryCommnetId { get; set; }
        public VoteType VoteType { get; set; }
        public Guid CreatedBy { get; set; }

        public CreateEntryCommentVoteCommand(Guid entryCommnetId, VoteType voteType, Guid createdBy)
        {
            EntryCommnetId = entryCommnetId;
            VoteType = voteType;
            CreatedBy = createdBy;
        }

        public CreateEntryCommentVoteCommand()
        {
        }
    }



}
