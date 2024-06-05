using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polling_Page_Administration_Task.Models;
using Polling_Page_Administration_Task.Services;
using Polling_Page_Administration_Task.ViewModels;

namespace Polling_Page_Administration_Task.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IServiceBase<Poll> _pollService;
        private readonly IServiceBase<Question> _questionService;
        public QuestionController(IServiceBase<Question>
            questionService, IServiceBase<Poll> pollService)
        {
            _questionService = questionService;
            _pollService = pollService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CreateQuestion(int pollId)
        {
            var poll = _pollService.Get(pollId);
            if (poll == null)
            {
                return NotFound();
            }
            var addnewQuestion = new AddQuestionViewModel { PollId = pollId, Answers = {"","","" } };
            return View(addnewQuestion); // Pass an empty PollQuestion for the form
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateQuestion(AddQuestionViewModel addnewQuestion)
        {
            Question pollQuestion;
            if (ModelState.IsValid) // Validate user input
            {
                 pollQuestion = new Question
                {
                    Text = addnewQuestion.Text,
                    Answers = addnewQuestion.Answers.Select(a => new Answer { Text = a }).ToList(),
                    PollId = addnewQuestion.PollId
                };

                _questionService.Add(pollQuestion);
                return RedirectToAction("Polls","Poll");
            }
            return View(addnewQuestion);
        }

    }
}
