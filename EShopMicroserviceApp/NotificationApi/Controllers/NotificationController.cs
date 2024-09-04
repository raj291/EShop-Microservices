using Microsoft.AspNetCore.Mvc;
using NotificationApi.MessagingQueue;

namespace NotificationApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private QueueService _queueService;
    public NotificationController(IConfiguration configuration)
    {
        _queueService = new QueueService(configuration);
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var message = await _queueService.ReadMsgAsync("orderqueue");
        return Ok(message);
    }
   
}