using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Register.Models;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegisterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)

        {
           
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyDBConnection"));
            SqlCommand command = new SqlCommand("INSERT INTO Register(userName,password,email) VALUES('"+registration.userName+ "', '" + registration.password + "','" + registration.email+"' )");
            con.Open();
            command.Connection = con;
            int i = command.ExecuteNonQuery();
            con.Close();
            if(i > 0)
            {
                return "გილოცავთ თქვენ წარმატებით გაიარეთ რეგისტრაცია";
            }
            else
            {
                return "Error";
            }

        }

        [HttpPost]
        [Route("login")]
        //public string login(Registration registration)
        public IActionResult login([FromBody] User registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyDBConnection"));
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Register WHERE userName= '"+ registration.userName +"' AND password ='"+ registration.password+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Ok("valid user");
            }
            else
            {
                return BadRequest("ასეთი მომხმარებელი არ არსებობს");
            }
        }
    }
}
