using AutoMapper;
using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Common;
using BlazorForum.Common.Events.Entry;
using BlazorForum.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.Entry.Create
{
    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IEntryRepository entryRepository;

        public CreateEntryCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.entryRepository = entryRepository;
        }

        public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            var dbEntry = mapper.Map<BlazorForum.Api.Domain.Models.Entry>(request);

            await entryRepository.AddAsync(dbEntry);

            return dbEntry.Id;
        }
    }
}
