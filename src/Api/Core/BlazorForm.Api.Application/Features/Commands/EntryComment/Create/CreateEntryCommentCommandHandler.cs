using AutoMapper;
using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Common.Models.RequestModels;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.EntryComment.Create;

public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentCommand, Guid>
{

    private readonly IEntryCommentRepository entryCommentRepository;
    private readonly IMapper mapper;

    public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
    {
        this.entryCommentRepository = entryCommentRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateEntryCommentCommand request, CancellationToken cancellationToken)
    {

        var dbEntryComment = mapper.Map<BlazorForum.Api.Domain.Models.EntryComment>(request);

        await entryCommentRepository.AddAsync(dbEntryComment);

        return dbEntryComment.Id;
    }
}



