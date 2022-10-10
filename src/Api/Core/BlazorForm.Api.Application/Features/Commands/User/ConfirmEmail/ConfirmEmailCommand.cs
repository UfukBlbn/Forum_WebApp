using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public Guid ConfitmationId { get; set; }

    }

    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailConfirmationRepository emailConfirmationRepository;

        public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfirmationRepository emailConfirmationRepository)
        {
            this.userRepository = userRepository;
            this.emailConfirmationRepository = emailConfirmationRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirmation = emailConfirmationRepository.GetByIdAsync(request.ConfitmationId);

            if (confirmation is null)
                throw new DatabaseValidationException("Confirmation not found!");

            var dbUser = await userRepository.GetSingleAsync(u => u.EmailAddress == confirmation.Result.NewEmailAddress);
            
            if (dbUser is null)
                throw new DatabaseValidationException("User not found with this email!");
            
            if (dbUser.EmailConfirmed)
                throw new DatabaseValidationException("Email address is already confirmed!");

            dbUser.EmailConfirmed = true;
            await userRepository.UpdateAsync(dbUser);

            return true;

        }
    }
}
