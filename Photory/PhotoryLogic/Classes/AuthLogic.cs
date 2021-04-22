using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryLogic.Classes
{
    public class AuthLogic
    {

        UserManager<IdentityUser> _userManager; //user repó
        RoleManager<IdentityRole> _roleManager; //role repó
        IUserRepository userrepo;

        public AuthLogic(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserRepository userrepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.userrepo = userrepo;
        }


        public IEnumerable<IdentityUser> GetAllUser()
        {
            return _userManager.Users;
        }

        public async Task<string []> RegisterUser(RegisterViewModel model)
        {
            var user2 = await _userManager.FindByEmailAsync(model.Email);

            if (user2 == null)
            {

                var guidId = Guid.NewGuid().ToString();

               

                var user = new IdentityUser
                {
                    Id = guidId,//update
                    Email = model.Email,
                    UserName = model.UserName,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                string psswrd = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user, psswrd);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    //Aki beregisztál, az bekerül a User táblába is (szinkron)
                    User u = new User();
                    u.FullName = model.FullName;
                    u.BirthDate = model.BirthDate;
                    u.Email = model.Email;
                    //u.Password = model.Password;
                    u.UserAccess = UserAccess.RegularUser;
                    u.UserId = guidId;
                    u.UserName = model.UserName;

                    userrepo.Add(u);
                }

                string[] returnarray = new string[3];
                returnarray[0] = user.UserName;
                returnarray[1] = user.Email;
                returnarray[2] = psswrd;
                return returnarray;
            }

            throw new ArgumentException("Email Alredy Exists");
        }

        public async Task<TokenViewModel> LoginUser(LoginViewModel model)
        {
            IdentityUser user;
            bool validemail = IsValidEmail(model.ValidationName);

            if (validemail)
            {
                 user = await _userManager.FindByEmailAsync(model.ValidationName);
            }
            else
            { 
            
              user = await _userManager.FindByNameAsync(model.ValidationName);
            }

           
           

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {


                var claims = new List<Claim>
                {
                  new Claim(JwtRegisteredClaimNames.Sub, model.ValidationName),
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
            throw new ArgumentException("Login failed");
        }



        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
