namespace Polling_Page_Administration_Task.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int PollId { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
