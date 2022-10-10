using BlazorForm.Api.Application.Interfaces.Repositories;
using BlazorForum.Common.Events.User;
using BlazorForum.Common.Infrastructure;
using BlazorForum.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.User.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>

    {
        private readonly IUserRepository userRepository;

        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue)
            {
                throw new ArgumentNullException(nameof(request.UserId));
            }
            var dbUser = await userRepository.GetByIdAsync(request.UserId.Value);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found");

            //Encyrpt process...
            var encryptedPass = PasswordEncyrptor.Encyrpt(request.OldPassword);
            if (dbUser.Password != encryptedPass)
                throw new DatabaseValidationException("Old password wrong !");
             
            dbUser.Password = encryptedPass;

            await userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
