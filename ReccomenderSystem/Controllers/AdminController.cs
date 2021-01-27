using LMRS.Repositories;
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
    public class AdminController : Controller
    {
        private readonly IStudentService _studentService;

        public AdminController(
            IStudentService studentService
        )
        {
            _studentService = studentService;
        }
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var result = _studentService.GetStudents();
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
