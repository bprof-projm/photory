using Microsoft.AspNetCore.Mvc;
using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Facebook;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using PhotoryRepository.Interfaces;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using PhotoryLogic.Classes;

namespace Photory.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("ExternalAuth")]
    public class ExternalAuthController : Controller
    {
        ExternalAuthLogic externalAuthLogic;

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
