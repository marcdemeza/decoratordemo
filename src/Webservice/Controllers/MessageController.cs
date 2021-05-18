using Microsoft.AspNetCore.Mvc;
using Webservice.Services;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public string Get() => _messageService.Get().Message;
    }
}
