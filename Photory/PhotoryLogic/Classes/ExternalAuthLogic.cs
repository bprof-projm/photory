using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryLogic.Classes
{
    public class ExternalAuthLogic
    {
        private FacebookOptions facebookOptions;
        private UserManager<IdentityUser> _userManager;
        private IUserRepository userrepo;
        private static readonly HttpClient Client = new HttpClient();

        public ExternalAuthLogic(UserManager<IdentityUser> userManager, IUserRepository userrepo)
        {
            _userManager = userManager;
            this.userrepo = userrepo;
            facebookOptions = new FacebookOptions();
            facebookOptions.AppId = "287947399346523";
            facebookOptions.AppSecret = "248cb1d0529819d6cd2530995a09b00b";
        }

        public async Task<TokenViewModel> FacebookLogin(FacebookLoginViewModel model)
        {
            var appAccessTokenResponse = await Client.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={facebookOptions.AppId}&client_secret={facebookOptions.AppSecret}&grant_type=client_credentials");
            var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);

            var userAccessTokenValidationResponse = await Client.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={model.AccessToken}&access_token={appAccessToken.AccessToken}");
            var userAccessTokenValidation = JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);

            if (!userAccessTokenValidation.Data.IsValid)
            {
                throw new ArgumentException("Invalid Facebook token");
            }

            var userInfoResponse = await Client.GetStringAsync($"https://graph.facebook.com/v10.0/me?fields=id,name,birthday,email,picture,gender&access_token={model.AccessToken}");
            var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);

            //JSON DATE TIME CONVERT
            JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(userInfoResponse) as JObject;
            jObject.SelectToken("birthday").Replace(Convert.ToDateTime(jObject.SelectToken("birthday")));
            var vmi2 = jObject.SelectToken("birthday");
            userInfo.Birthdate = Convert.ToDateTime(vmi2);

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
                    throw new ArgumentException("failed user create");
                }
            }
            // generate the jwt for the local user...
            var localUser = await _userManager.FindByEmailAsync(userInfo.Email);

            if (localUser == null)
            {
                throw new ArgumentException("login failed local user not found");
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
            return new TokenViewModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}