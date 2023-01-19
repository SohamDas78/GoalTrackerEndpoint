using GoalTrackerEndpoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoalTrackerEndpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserContext userContext;

        public UserController(UserContext userctx, ILogger<UserController> logger)
        {
            _logger = logger;
            userContext= userctx;
        }

        [HttpPost(Name = "Fetch")]
        [Route("Fetch")]
        public IEnumerable<User> Get()
        {
            return userContext.Users.ToList();
        }
    }
}