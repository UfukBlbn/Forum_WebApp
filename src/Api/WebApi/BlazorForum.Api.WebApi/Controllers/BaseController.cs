using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BlazorForum.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        //We will get it with JWT Token..!
        public Guid UserId => Guid.NewGuid(); //new(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
