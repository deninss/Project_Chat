using API.HubController;
using API.Services.searchServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class hubController : ControllerBase
    {
       /* private readonly IHubContext<hubContext> _hubContext;
        protected ISearchService _searchService { get; }

        public hubController(IHubContext<hubContext> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message, string connectionId)
        {
            var results = await _searchService.SearchUserAsync(message);
            await _hubContext.Clients.Client(connectionId).SendAsync("SearchResultsUser", results);
            return Ok(new { Message = "Message sent" });
        }*/
    }
}
