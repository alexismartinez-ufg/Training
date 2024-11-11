using Microsoft.AspNetCore.Mvc;
using UsersCrudWithFluentValidations.Models;

namespace UsersCrudWithFluentValidations.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Lista estática para almacenar los usuarios en memoria
        private static List<User> Users { get; set; } = [];
        private static int NextId { get; set; } = 1;

        // GET: api/user
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(Users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] User user)
        {
            user.Id = NextId++;
            Users.Add(user);
            return Ok(user);
        }

        // PUT: api/user
        [HttpPut]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put([FromBody] User user)
        {
            var existingUser = Users.Find(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser = user;

            return Ok(existingUser);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            Users.Remove(user);
            return NoContent();
        }
    }
}
