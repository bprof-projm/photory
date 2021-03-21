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
    [Route("{UserComment}")]
    public class UserCommentController
    {
        UserLogic userlogic;

        public UserCommentController(UserLogic userlogic)
        {
            this.userlogic = userlogic;
        }


        [HttpPost]
        public void AddComment([FromBody] Comment m)
        {
            userlogic.AddComment(m);

        }

        [HttpDelete("{id}")]
        public void DeleteComment(string id)
        {
            userlogic.DeleteComment(id);
        }




    }
}
