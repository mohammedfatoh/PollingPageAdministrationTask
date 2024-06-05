using Microsoft.AspNetCore.Mvc;
using Polling_Page_Administration_Task.Models;
using Polling_Page_Administration_Task.Services;

namespace Polling_Page_Administration_Task.Controllers
{
    public class ClientController : Controller
    {
        private readonly IServiceBase<Poll> pollService;

        public ClientController(IServiceBase<Poll> pollService)
        {
            this.pollService = pollService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetLastPoll()
        {
            var poll = pollService.GetLast();
            if (poll == null)
            {
                return NotFound();
            }
            return View(poll);
        }
    }
}
