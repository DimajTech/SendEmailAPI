using Microsoft.AspNetCore.Mvc;

using SendEmailAPI.Service;
using SendEmailAPI.Model;
namespace SendEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public SendEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SendEmail(Email request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }

    }
}
