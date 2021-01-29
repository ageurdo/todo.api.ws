using System.Collections.Generic;
using todo.api.ws.Models;

namespace todo.api.ws.Repository
{
    public interface IStatusTaskRepository
    {
        void Add(StatusTask statusTask);
        IEnumerable<StatusTask> GetAll();
        StatusTask Find(int id);
        void Remove(int id);
        void Update(StatusTask statusTask);
    }
}
