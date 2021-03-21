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
    [Route("{UserPhoto}")]
    public class UserPhotoController
    {

        UserLogic userlogic;

        public UserPhotoController(UserLogic userlogic)
        {
            this.userlogic = userlogic;
        }


        [HttpPost]
        public void AddPhoto([FromBody] Photo p)
        {
            userlogic.AddPhoto(p);

        }

        [HttpDelete("{id}")]
        public void DeletePhoto(string id)
        {
            userlogic.DeletePhoto(id);
        }




    }
}
