namespace Polling_Page_Administration_Task.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int VoteCount { get; set; } 
        public int QuestionId { get; set; }
    }
}
