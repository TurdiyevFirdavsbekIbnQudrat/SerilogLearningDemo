using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Serilog;
using Serilog.Context;
using System;
using System.Diagnostics;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SerilogLearningDemo.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly SerilogDb _context;
        private readonly ILogger<UserController> _logger;
        private readonly IHttpClientFactory _http;

        public UserController(SerilogDb context, ILogger<UserController> logger,IHttpClientFactory http)
        {
            _context = context;
            _logger = logger;
            _http = http;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _logger.LogTrace("Bu trace log ");
            var timestamp = DateTime.UtcNow;

            using (LogContext.PushProperty("CreateTimeUtc", timestamp))
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                _logger.LogInformation("Yangi foydalanuvchi yaratildi: {@User}", user);

                return Ok(new
                {
                    Message = "Foydalanuvchi yaratildi",
                    CreatedUser = user,
                    CreatedAt = timestamp
                });
            }
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var http = _http.CreateClient("serilog");
            var baseAddress = http.BaseAddress;
           
            var users = _context.Users.ToList();
            return Ok(new
            {
                baseAddress,
                users
            });
        }
    }
}
