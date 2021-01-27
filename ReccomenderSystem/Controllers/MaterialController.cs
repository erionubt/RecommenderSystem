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
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(
            IMaterialService materialService
        )
        {
            _materialService = materialService;
        }

        [HttpGet("GetSearchedMaterials/{materiali}")]
        public async Task<IActionResult> GetSearchedMaterials(string materiali)
        {
            try
            {
                var result = _materialService.GetSearchedMaterials(materiali);
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
