using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SerilogLearningDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ForHttpClientController : ControllerBase
    {
        private readonly ForHttpClient _httpClient;
        public ForHttpClientController(ForHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await  _httpClient.GetAll());
        }
    }
}
