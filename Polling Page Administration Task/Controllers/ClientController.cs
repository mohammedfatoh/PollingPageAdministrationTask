using Microsoft.AspNetCore.Mvc;
using Polling_Page_Administration_Task.Models;
using Polling_Page_Administration_Task.Services;

namespace Polling_Page_Administration_Task.Controllers
{
    public class ClientController : Controller
    {
        private readonly IServiceBase<Poll> pollService;
        private readonly IServiceBase<Answer> answerService;

        public ClientController(IServiceBase<Poll> pollService, IServiceBase<Answer> answerService)
        {
            this.pollService = pollService;
            this.answerService = answerService;
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

        [HttpPost]
        public IActionResult Vote(int pollId, int answerid)
        {
            var poll = pollService.Get(pollId);
            if (poll == null)
            {
                return NotFound();
            }

            answerService.Update(answerid, null);
           

            return RedirectToAction("GetLastPoll");
        }
    } 
}
