using System.Collections.Generic;
using todo.api.ws.Models;

namespace todo.api.ws.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(int id);
        void Remove(int id);
        void Update(User user);
    }
}
