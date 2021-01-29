using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using todo.api.ws.Models;
using todo.api.ws.Repository;

namespace todo.api.ws.Controllers
{
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepo)
        {
            _userRepository = userRepo;

        }
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPost]
         public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _userRepository.Add(user);

            return CreatedAtRoute("GetUser", new User { UserId = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update (int id, [FromBody] User user){ 
        if (user==null || user.UserId != id)
            return BadRequest();
            
            var _user = _userRepository.Find(id);
            
            if (_user == null)
                return NotFound();

            _user.Email = user.Email;
            _user.Name = user.Name;

            _userRepository.Update(_user);
            return new NoContentResult();
    }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _user = _userRepository.Find(id);

            if (_user == null)
                return NotFound();
            
            _userRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
