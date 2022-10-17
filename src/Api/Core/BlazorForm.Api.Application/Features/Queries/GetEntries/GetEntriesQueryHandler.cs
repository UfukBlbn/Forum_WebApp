using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorForm.Api.Application.Features.Queries.GetEntries;
using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, List<GetEntriesViewModal>>
{
    private readonly IEntryRepository entryRepository;
    private readonly IMapper mapper;

    public GetEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        this.entryRepository = entryRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetEntriesViewModal>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = entryRepository.AsQueryable();

        if (request.TodaysEntries)
        {
            query = query
                  .Where(u => u.CreatedDate >= DateTime.Now.Date)
                  .Where(u => u.CreatedDate < DateTime.Now.AddDays(1).Date);
        }

        query = query.Include(u => u.EntryComments)
            .OrderBy(u => Guid.NewGuid())
            .Take(request.Count);

        return await query.ProjectTo<GetEntriesViewModal>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
