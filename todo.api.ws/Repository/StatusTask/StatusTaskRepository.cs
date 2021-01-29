using System.Collections.Generic;
using System.Linq;
using todo.api.ws.Dal;
using todo.api.ws.Models;

namespace todo.api.ws.Repository.Status
{
    public class StatusTaskRepository : IStatusTaskRepository
    {
        private readonly EntityContext _context;
        public StatusTaskRepository( EntityContext ctx)

        {
            _context = ctx;
        }
        public void Add(StatusTask statusTask)
        {
            _context.StatusTask.Add(statusTask);
            _context.SaveChanges();
        }

        public StatusTask Find(int id)
        {
            return _context.StatusTask.FirstOrDefault(u => u.StatusId == id);
        }

        public IEnumerable<StatusTask> GetAll()
        {
            return _context.StatusTask.ToList();
        }

        public void Remove(int id)
        {
            var entity = _context.StatusTask.First(u => u.StatusId == id);
            _context.StatusTask.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(StatusTask statusTask)
        {
            _context.StatusTask.Update(statusTask);
            _context.SaveChanges();
        }
    }
}
