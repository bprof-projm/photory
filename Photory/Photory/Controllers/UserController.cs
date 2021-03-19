using Microsoft.AspNetCore.Mvc;
using PhotoryLogic.Classes;
using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photory.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class UserController : ControllerBase
    {
        UserLogic userlogic;

        public UserController(UserLogic userlogic)
        {
            this.userlogic = userlogic;
        }


        [HttpPost]
        public void CreateUser([FromBody] User user)
        {
            userlogic.CreateUser(user);
        }


        [HttpGet]
        public IEnumerable<User> GetAllUser()
        {
            return userlogic.GetAllUser();
        }

    }
}

