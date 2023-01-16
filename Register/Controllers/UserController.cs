using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Register.Models;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        public UserController(IConfiguration config)
        {
            _config = config;
        }

        private readonly User[] _users =
        {
            new User {userName = "test1",userPassword = "1234"},
            new User {userName = "test2",userPassword = "1234"},
            new User {userName = "test3",userPassword = "1234"},
        };





        [HttpPost("CreateUser")]

        public IActionResult Create([FromBody] User user)

        {
            var CreateUser = _users.FirstOrDefault(u => u.userName == user.userName && u.userPassword == user.userPassword);

            if (CreateUser != null)
            {
                return Ok("გილოცავთ თქვენ წარმატებულად გაიარეთ ავტორიზაცია");
            } else
            {
                return BadRequest("ასეთი მომხმარებელი არ არსებობს,შეიყვანეთ სწორი სახელი და პაროლი");
            }

         
        }



        private class EnableCorsAttribute : Attribute
        {
            public EnableCorsAttribute(string v)
            {
            }
        }
    }
}

/*
 * https://localhost:7153/
 */