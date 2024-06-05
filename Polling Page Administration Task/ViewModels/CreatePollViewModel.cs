namespace Polling_Page_Administration_Task.ViewModels
{
    public class CreatePollViewModel
    {
        public string Title { get; set; }
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
    }
}
