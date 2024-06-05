using Polling_Page_Administration_Task.Data;
using Polling_Page_Administration_Task.Models;

namespace Polling_Page_Administration_Task.Services
{
    public class QuestionService : IServiceBase<Question>
    {
        private readonly ApplicationDbContext context;
        public QuestionService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int Add(Question Model)
        {
            context.Questions.Add(Model);
            context.SaveChanges();
            return Model.Id;
        }

        public Question Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetLast()
        {
            throw new NotImplementedException();
        }

        public int Update(int Id, Question Model)
        {
            throw new NotImplementedException();
        }
    }
}
