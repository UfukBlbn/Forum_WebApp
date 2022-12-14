using BlazorForm.Api.Application.Features.Queries.GetEntries;
using BlazorForm.Api.Application.Features.Queries.GetMainPageEntries;
using BlazorForum.Common.Events.Entry;
using BlazorForum.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorForum.Api.WebApi.Controllers
{
    public class EntryController : BaseController
    {

        private readonly IMediator mediator;

        public EntryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntries([FromQuery] GetEntriesQuery query)
        {
            var entries = await mediator.Send(query);

            return Ok(entries);
        }

        [HttpGet]
        [Route("GetMainPageEntries")]
        public async Task<IActionResult> GetMainPageEntries(int page, int pageSize)
        {
            var entries = await mediator.Send(new GetMainPageEntriesQuery(UserId,page,pageSize));

            return Ok(entries);
        }


        [HttpPost]
        [Route("CreateEntry")]
        public async Task<IActionResult> CreateEntry([FromBody] CreateEntryCommand command)
        {
            if (!command.CreatedById.HasValue)
                command.CreatedById = UserId;

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("CreateEntryComment")]
        public async Task<IActionResult> CreateEntryComment([FromBody] CreateEntryCommentCommand command)
        {
            if (!command.CreatedById.HasValue)
                command.CreatedById = UserId;

            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
