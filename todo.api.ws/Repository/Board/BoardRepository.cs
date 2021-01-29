using System.Collections.Generic;
using System.Linq;
using todo.api.ws.Dal;
using todo.api.ws.Models;

namespace todo.api.ws.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private readonly EntityContext _context;
        public BoardRepository(EntityContext ctx)
        {
            _context = ctx;
        }

        public void Add(Board board)
        {
            _context.Boards.Add(board);
            _context.SaveChanges();
        }

        public Board Find(int id)
        {
            return _context.Boards.FirstOrDefault(u => u.BoardId == id);
        }

        public IEnumerable<Board> GetAll()
        {
            return _context.Boards.ToList();
        }

        public void Remove(int id)
        {
            var entity = _context.Boards.First(u => u.BoardId == id);
            _context.Boards.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Board board)
        {
            _context.Boards.Update(board);
            _context.SaveChanges();
        }
    }
}
