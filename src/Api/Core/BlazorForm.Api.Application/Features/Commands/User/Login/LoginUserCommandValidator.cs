using BlazorForum.Common.Models.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Api.Application.Features.Commands.User.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.EmailAddress)
                    .NotNull()
                    .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                    .WithMessage("{ProportName} not a valid email address");

            RuleFor(u => u.Password)
                    .MinimumLength(6)
                    .WithMessage("{ProportName} should at least be {MinLength} characters");
        }

    }
}
