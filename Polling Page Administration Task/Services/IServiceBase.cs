using Polling_Page_Administration_Task.Models;

namespace Polling_Page_Administration_Task.Services
{
    public interface IServiceBase<T>
    {
        Task<List<T>> GetAll();
        int Add(T Model);

        T Get(int id);

        T GetLast();

    }


}
