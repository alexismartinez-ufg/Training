using Microsoft.AspNetCore.Mvc;
using UsersCrudWithFluentValidations.Models;

namespace UsersCrudWithFluentValidations.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<User>());
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            return Ok(user);
        }
    }
}
