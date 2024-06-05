using Microsoft.EntityFrameworkCore;
using Polling_Page_Administration_Task.Data;
using Polling_Page_Administration_Task.Models;

namespace Polling_Page_Administration_Task.Services
{
    public class PollService : IServiceBase<Poll>
    {
        private readonly ApplicationDbContext context;
        public PollService(ApplicationDbContext context)
        {
            this.context = context;
        }   
        public int Add(Poll Model)
        {
            context.Polls.Add(Model);   
            context.SaveChanges();
            return Model.Id;
        }

        public async Task<List<Poll>> GetAll()
        {
            return await context.Polls.Include(p => p.Questions)
                .ThenInclude(q => q.Answers)
            .ToListAsync();
        }

        public int AddPollQuestion(Question Question)
        {
            context.Questions.Add(Question);
            context.SaveChanges();
            return Question.Id;
        }

        public Poll Get(int Id)
        {
            return context.Polls.Include(p => p.Questions)
                              .ThenInclude(q => q.Answers)
                              .FirstOrDefault(p => p.Id == Id);
        }

        public Poll GetLast()
        {
            return context.Polls.Include(p => p.Questions)
                              .ThenInclude(q => q.Answers)
                             .OrderByDescending(p => p.Id)
                             .FirstOrDefault();
        }

        public int Update(int Id, Poll Model)
        {
            throw new NotImplementedException();
        }
    }
}
