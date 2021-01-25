using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReccomenderSystem.Interfaces;
using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController : Controller
    {
        private readonly ITopicsRepository _topicsRepository;
        //private readonly IStudentRepository _studentRepository;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public TopicsController(
            ITopicsRepository topicsRepository,
            IStudentRepository studentRepository,
            SignInManager<ApplicationUser> signManager,
            UserManager<ApplicationUser> userManager
        )
        {
            _topicsRepository = topicsRepository;
            //_studentRepository = studentRepository;
            _signManager = signManager;
            _userManager = userManager;
        }

        [HttpGet("GetTopics")]
        public async Task<IActionResult> GetTopics()
        {
            try
            {
                var result = await _topicsRepository.GetTopics();
                return Ok(result);
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex?.Message });
            }
        }

        [HttpPost("SaveTopic/{emri}")]
        public IActionResult SaveTopic(string emri)
        {
            try
            {
                var result = _topicsRepository.SaveTopics(emri);
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
