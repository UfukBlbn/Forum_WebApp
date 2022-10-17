using AutoMapper;
using BlazorForum.Api.Domain.Models;
using BlazorForum.Common.Events.Entry;
using BlazorForum.Common.Models.Queries;
using BlazorForum.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();

            CreateMap<User, CreateUserCommand>()
                .ReverseMap();

            CreateMap<User, UpdateUserCommand>()
                .ReverseMap();

            CreateMap<Entry, CreateEntryCommand>()
                .ReverseMap();

            CreateMap<Entry, GetEntriesViewModal>()
                .ForMember(x=>x.CommentCount, y=>y.MapFrom(z=>z.EntryComments.Count)); 
            
            CreateMap<CreateEntryCommentCommand,EntryComment>()
                .ReverseMap();
        }
    }
}
