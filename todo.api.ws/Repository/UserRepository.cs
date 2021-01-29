using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo.api.ws.Dal;
using todo.api.ws.Models;

namespace todo.api.ws.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EntityContext _context;
        public UserRepository(EntityContext ctx)
        {
            _context = ctx;       
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Find(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Remove(int id)
        {
            var entity = _context.Users.First(u => u.UserId == id);
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
