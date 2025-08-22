using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    //https://localhost:port/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        //action method
        //GET: https://localhost:port/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "Sadia", "Sidra", "Ayesha" };
            return Ok(studentNames);
        }
    }
}
