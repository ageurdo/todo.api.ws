using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using todo.api.ws.Models;
using todo.api.ws.Repository.Tasks;

namespace todo.api.ws.Controllers
{
    [Route("api/[Controller]")]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepo)
        {
            _taskRepository = taskRepo;

        }
        [HttpGet]
        public IEnumerable<Task> GetAll()
        {
            return _taskRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTask")]
        public IActionResult GetById(int id)
        {
            var task = _taskRepository.Find(id);
            if (task == null)
                return NotFound();

            return new ObjectResult(task);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Task task)
        {
            if (task == null)
                return BadRequest();

            _taskRepository.Add(task);

            return CreatedAtAction(nameof(GetById), new { id = task.TaskId }, task);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Task task)
        {
            if (task == null || task.TaskId != id)
                return BadRequest();

            var _task = _taskRepository.Find(id);

            if (_task == null)
                return NotFound();

            _task.Name = task.Name;
            _task.BoardId = task.BoardId;
            _task.StatusId = task.StatusId;
            _task.UserId = task.UserId;

            _taskRepository.Update(_task);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _task = _taskRepository.Find(id);

            if (_task == null)
                return NotFound();

            _taskRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
