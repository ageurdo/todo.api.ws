using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using todo.api.ws.Models;
using todo.api.ws.Repository;

namespace todo.api.ws.Controllers
{
    [Route("api/[Controller]")]
    public class BoardsController : Controller
    {
        private readonly IBoardRepository _boardRepository;

        public BoardsController(IBoardRepository boardRepo)
        {
            _boardRepository = boardRepo;

        }
        [HttpGet]
        public IEnumerable<Board> GetAll()
        {
            return _boardRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetBoard")]
        public IActionResult GetById(int id)
        {
            var board = _boardRepository.Find(id);
            if (board == null)
                return NotFound();

            return new ObjectResult(board);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Board board)
        {
            if (board == null)
                return BadRequest();

            _boardRepository.Add(board);

            return CreatedAtAction(nameof(GetById), new { id = board.BoardId }, board);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Board board)
        {
            if (board == null || board.BoardId != id)
                return BadRequest();

            var _board = _boardRepository.Find(id);

            if (_board == null)
                return NotFound();

            _board.Name = board.Name;
            _board.Description = board.Description;

            _boardRepository.Update(_board);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _board = _boardRepository.Find(id);

            if (_board == null)
                return NotFound();

            _boardRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
