namespace Polling_Page_Administration_Task.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
