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

        [HttpPost]
        [Route("Fetch")]
        public IEnumerable<User> Get()
        {
            return userContext.Users.ToList();
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<string> Signup(UserReadModel user)
        {
            try
            {
                await userContext.Users.AddAsync(new User() { UserId = Guid.NewGuid(), UserName = user.UserName, Password = user.Password });
                await userContext.SaveChangesAsync();
                return "Success";
            }
            catch(Exception ex)
            {
                return $"Failed - {ex.Message}";
            }
        }
    }
}