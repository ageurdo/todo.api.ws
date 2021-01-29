using System.Collections.Generic;
using System.Linq;
using todo.api.ws.Dal;
using todo.api.ws.Models;

namespace todo.api.ws.Repository.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        private readonly EntityContext _context;
        public TaskRepository(EntityContext ctx)
        {
            _context = ctx;
        }
        public void Add(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public Task Find(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.TaskId == id);
        }

        public IEnumerable<Task> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public void Remove(int id)
        {
            var entity = _context.Tasks.First( t => t.TaskId == id);
            _context.Tasks.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

    }
}
