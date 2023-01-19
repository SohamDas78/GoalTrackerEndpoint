using Microsoft.AspNetCore.Mvc;

namespace GoalTrackerEndpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Fetch")]
        [Route("Fetch")]
        public IEnumerable<string> Get()
        {
            return Enumerable.Range(1, 5).Select(index => index.ToString()).ToArray();
        }
    }
}