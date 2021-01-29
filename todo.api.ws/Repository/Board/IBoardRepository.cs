using System.Collections.Generic;
using todo.api.ws.Models;

namespace todo.api.ws.Repository
{
    public interface IBoardRepository
    {
        void Add(Board board);
        IEnumerable<Board> GetAll();
        Board Find(int id);
        void Remove(int id);
        void Update(Board board);
    }
}
