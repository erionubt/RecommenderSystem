using Microsoft.AspNetCore.Mvc;
using ReccomenderSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(
           IStudentService studentService
        )
        {
            _studentService = studentService;
        }

        [HttpGet("GetMaterialsForUser/{id}")]
        public async Task<IActionResult> GetMaterialsForUser(string id)
        {
            try
            {
                var result = _studentService.GetMaterialsForUser(id);
                return Ok(result);
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex?.Message });
            }
        }
    }
}
