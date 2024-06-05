using Polling_Page_Administration_Task.Data;
using Polling_Page_Administration_Task.Models;

namespace Polling_Page_Administration_Task.Services
{
    public class AnswerService : IServiceBase<Answer>
    {
        private readonly ApplicationDbContext context;
        public AnswerService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int Add(Answer Model)
        {
            throw new NotImplementedException();
        }

        public Answer Get(int id)
        {
            return context.Answers.FirstOrDefault(a => a.Id == id);
        }

        public Task<List<Answer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Answer GetLast()
        {
            throw new NotImplementedException();
        }

        public int Update(int Id, Answer Model)
        {
            var answer = Get(Id);
            if (answer != null)
            {
                answer.VoteCount++;
                context.SaveChanges();
            }
            return 1;
        }
    }
}
