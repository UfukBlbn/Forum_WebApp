using AutoMapper;
using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Common;
using BlazorForum.Common.Events.User;
using BlazorForum.Common.Infrastructure;
using BlazorForum.Common.Infrastructure.Exceptions;
using BlazorForum.Common.Models.RequestModels;
using MediatR;

namespace BlazorForm.Api.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);
            if (existUser is not null)
            {
                throw new DatabaseValidationException("User already exist");
            }

            var dbUser = mapper.Map<BlazorForum.Api.Domain.Models.User>(request);

            var rows = await userRepository.AddAsync(dbUser);

            if (rows >0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    NewEmailAddress = request.EmailAddress,
                    OldEmailAddress = null
                };

                QueueFactory.SendMessageToExchange(exchangeName: ForumConstants.UserExchangeName, exchangeType: ForumConstants.DefaultExchangeType, queueName: ForumConstants.UserEmailChangedQueueName, obj: @event);
            }

            return dbUser.Id;
        }
 
    }
}
