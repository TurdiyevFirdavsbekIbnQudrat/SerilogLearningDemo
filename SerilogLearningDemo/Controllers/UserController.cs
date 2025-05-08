using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace SerilogLearningDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly SerilogDb _context;
        public UserController(SerilogDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateBackingField(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            using (var log = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger())
            {
                log.Information("This is an informational message.");
                log.Warning("This is a warning for testing purposes.");
}
            return Ok(user);
        }
    }
}
