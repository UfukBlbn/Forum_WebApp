using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Common;
using BlazorForum.Common.Infrastructure.Extensions;
using BlazorForum.Common.Models.Page;
using BlazorForum.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorForm.Api.Application.Features.Queries.GetMainPageEntries
{
    public class GetMainPageEntriesQueryHandler : IRequestHandler<GetMainPageEntriesQuery, PagedViewModel<GetEntryDetailedViewModel>>
    {

        private readonly IEntryRepository entryRepository;


        public GetMainPageEntriesQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;

        }


        public async Task<PagedViewModel<GetEntryDetailedViewModel>> Handle(GetMainPageEntriesQuery request, CancellationToken cancellationToken)
        {

            var query = entryRepository.AsQueryable();

            query = query.Include(u => u.EntryFavorites)
                         .Include(u => u.EntryVotes)
                         .Include(u => u.CreatedBy);
            var list = query.Select(u => new GetEntryDetailedViewModel()
            {
                Id = u.Id,
                Subject = u.Subject,
                Content = u.Content,
                IsFavorited = request.UserId.HasValue && u.EntryFavorites.Any(b => b.CreatedById == request.UserId),
                FavoritedCount = u.EntryFavorites.Count,
                CreatedDate = u.CreatedDate,
                CreatedByUserName = u.CreatedBy.UserName,
                VoteType =
                           request.UserId.HasValue && u.EntryVotes.Any(b => b.CreatedById == request.UserId)
                           ? u.EntryVotes.FirstOrDefault(b => b.CreatedById == request.UserId).VoteType
                           : VoteType.None
            });

            //This extension metod is for Paging Action
            var entries = await list.GetPaged(request.Page, request.PageSize);

            return new PagedViewModel<GetEntryDetailedViewModel>(entries.Results,entries.PageInfo);

        }
    }
}
