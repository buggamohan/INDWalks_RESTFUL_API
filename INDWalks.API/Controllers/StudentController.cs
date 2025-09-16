using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll()
        {
            String[] students = new String[] {
                "mohan",
                "madhu"

            };

            return Ok(students);
        }
    }
}
