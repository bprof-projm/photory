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
    [Route("Content")]
    public class ContentController : ControllerBase
    {
        UserLogic userlogic;

        public ContentController(UserLogic userlogic)
        {
            this.userlogic = userlogic;
        }

        [HttpGet("GetAllCommentsFromPhoto/{photoID}")]
        public IQueryable<Comment> GetAllCommentsFromPhoto(string photoID)
        {
            return userlogic.GetAllCommentsFromPhoto(photoID);
        }


        [HttpGet("GetUserFromGroup/{userID}&{GroupID}")]

        public User GetUserFromGroup(string userID, string GroupID)
        {
           return  userlogic.GetUserFromGroup(userID, GroupID);
        }

    }
}
