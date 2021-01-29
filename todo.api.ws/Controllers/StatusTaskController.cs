using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using todo.api.ws.Models;
using todo.api.ws.Repository;

namespace todo.api.ws.Controllers
{
    [Route("api/[Controller]")]
    public class StatusTaskController : Controller
    {
        private readonly IStatusTaskRepository _statusRepository;

        public StatusTaskController( IStatusTaskRepository statusRepo)
        {
            _statusRepository = statusRepo;
        }
        [HttpGet]
        public IEnumerable<StatusTask> GetAll()
        {
            return _statusRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _statusRepository.Find(id);
            if (status == null)
                return NotFound();

            return new ObjectResult(status);
        }

        [HttpPost]
        public IActionResult Create([FromBody] StatusTask statusTask)
        {
            if (statusTask == null)
                return BadRequest();

            _statusRepository.Add(statusTask);

            return CreatedAtAction(nameof(GetById), new { id = statusTask.StatusId }, statusTask);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StatusTask statusTask)
        {
            if (statusTask == null || statusTask.StatusId != id)
                return BadRequest();

            var _statusTask = _statusRepository.Find(id);

            if (_statusTask == null)
                return NotFound();

            _statusTask.Description = statusTask.Description;
            _statusTask.Color = statusTask.Color;

            _statusRepository.Update(_statusTask);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _StatusTask = _statusRepository.Find(id);

            if (_StatusTask == null)
                return NotFound();

            _statusRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
