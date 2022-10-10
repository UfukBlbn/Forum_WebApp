using BlazorForm.Api.Application.Features.Commands.User.ConfirmEmail;
using BlazorForum.Common.Events.User;
using BlazorForum.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorForum.Api.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var guid = await mediator.Send(command);

            return Ok(guid);
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {

            if (!command.UserId.HasValue)
                command.UserId = UserId;

            var res = await mediator.Send(command);

            return Ok(res);
        }

    }
}
