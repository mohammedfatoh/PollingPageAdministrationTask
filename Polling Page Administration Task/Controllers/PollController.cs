using Microsoft.AspNetCore.Mvc;
using Polling_Page_Administration_Task.Models;
using Polling_Page_Administration_Task.Services;
using Polling_Page_Administration_Task.ViewModels;

namespace Polling_Page_Administration_Task.Controllers
{
    public class PollController : Controller
    {
        private readonly IServiceBase<Poll> pollService;
        public PollController(IServiceBase<Poll> pollService)
        { 
            this.pollService = pollService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Polls()
        {
            return View(await pollService.GetAll());
        }

        public IActionResult AddPoll()
        {

            var model = new CreatePollViewModel();
            // Initialize with one question and two answers as example
            model.Questions.Add(new QuestionViewModel { Answers = new List<string> { "", "","","" } });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPoll(CreatePollViewModel model)
        {
            Poll poll;
            if (!ModelState.IsValid)
                return View(model);
            else
            {
                
                poll = new Poll
                {
                    Title = model.Title,
                    Questions = model.Questions.Select(q => new Question
                    {
                        Text = q.Text,
                        Answers = q.Answers.Select(a => new Answer { Text = a }).ToList()
                    }).ToList()
                };

            }
            try
            {
                pollService.Add(poll);
                return RedirectToAction("Polls");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(poll);
            }
            return View();
        }

       
    }
}
