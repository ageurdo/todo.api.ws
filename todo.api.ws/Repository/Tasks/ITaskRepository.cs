using System.Collections.Generic;
using todo.api.ws.Models;

namespace todo.api.ws.Repository.Tasks
{
    public interface ITaskRepository
    {
        void Add(Task task);
        List<Task> GetAll();
        Task Find(int id);
        void Remove(int id);
        void Update(Task task);
    }
}
