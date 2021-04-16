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

namespace Photory.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("ExternalAuth")]
    public class ExternalAuthController : Controller
    {
        public FacebookOptions FacebookOptions { get; set; }
        UserManager<IdentityUser> _userManager;
        IUserRepository userrepo;
        private static readonly HttpClient Client = new HttpClient();

        public ExternalAuthController(UserManager<IdentityUser> userManager, IUserRepository userrepo)
        {
            _userManager = userManager;
            this.userrepo = userrepo;
            FacebookOptions = new FacebookOptions();
            FacebookOptions.AppId = "287947399346523";
            FacebookOptions.AppSecret = "248cb1d0529819d6cd2530995a09b00b";
        }

        [HttpPost]
        public async Task<IActionResult> Facebook([FromBody] FacebookLoginViewModel model)
        {

            var appAccessTokenResponse = await Client.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={FacebookOptions.AppId}&client_secret={FacebookOptions.AppSecret}&grant_type=client_credentials");
            var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);

            var userAccessTokenValidationResponse = await Client.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={model.AccessToken}&access_token={appAccessToken.AccessToken}");
            var userAccessTokenValidation = JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);

            if (!userAccessTokenValidation.Data.IsValid)
            {
                return BadRequest("Invalid Facebook token");
            }

            var userInfoResponse = await Client.GetStringAsync($"https://graph.facebook.com/v10.0/me?fields=id,name,birthday,email,picture,gender&access_token={model.AccessToken}");
            var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);

            var user = await _userManager.FindByEmailAsync(userInfo.Email);

            if (user == null)
            {
                User u = new User();
                u.FullName = userInfo.Name;
                u.BirthDate = userInfo.Birthdate;
                u.Email = userInfo.Email;
                
                u.UserAccess = UserAccess.RegularUser;
                u.UserId = Guid.NewGuid().ToString();
                u.UserName = userInfo.Id.ToString();

                userrepo.Add(u);

                var user2 = new IdentityUser
                {
                    Id = u.UserId,//update
                    Email = u.Email,
                    UserName = u.UserName,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                string psswrd = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user2, psswrd);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user2, "Customer");
                }
                else
                {
                    return BadRequest("failed user create");
                }
            }

            // generate the jwt for the local user...
            var localUser = await _userManager.FindByEmailAsync(userInfo.Email);

            if (localUser == null)
            {
                return BadRequest("login failed local user not found");
            }

            var claims = new List<Claim>
                {
                  new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(ClaimTypes.NameIdentifier, user.Id)
                };


            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));


            var signinKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes("Paris Berlin Cairo Sydney Tokyo Beijing Rome London Athens"));

            var token = new JwtSecurityToken(
              issuer: "http://www.security.org",
              audience: "http://www.security.org",
              claims: claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            );
            TokenViewModel jwt = new TokenViewModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
            
            return new OkObjectResult(jwt);
        }
    }
}
