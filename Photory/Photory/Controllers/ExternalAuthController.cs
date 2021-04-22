using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoryLogic.Classes;
using PhotoryModels;
using System;
using System.Threading.Tasks;

namespace Photory.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("ExternalAuth")]
    public class ExternalAuthController : Controller
    {
        private ExternalAuthLogic externalAuthLogic;

        public ExternalAuthController(ExternalAuthLogic externalAuthLogic)
        {
            this.externalAuthLogic = externalAuthLogic;
        }

        [HttpPost]
        public async Task<IActionResult> Facebook([FromBody] FacebookLoginViewModel model)
        {
            try
            {
                return Ok(await externalAuthLogic.FacebookLogin(model));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}