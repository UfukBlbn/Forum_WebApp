using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.EntryComment.DeleteFav
{
    public class DeleteEntryCommentFavCommand : IRequest<bool>
    {
        public DeleteEntryCommentFavCommand()
        {
        }

        public Guid EntryCommentId { get; set; }

        public Guid DeletedBy { get; set; }

        public DeleteEntryCommentFavCommand(Guid entryCommentId, Guid deletedBy)
        {
            EntryCommentId = entryCommentId;
            DeletedBy = deletedBy;
        }
    }

}
