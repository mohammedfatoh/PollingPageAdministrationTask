namespace Polling_Page_Administration_Task.ViewModels
{
    public class AddQuestionViewModel
    {
        public int PollId { get; set; }
        public string Text { get; set; }

        public List<string> Answers { get; set; } = new List<string>();
    }
}
