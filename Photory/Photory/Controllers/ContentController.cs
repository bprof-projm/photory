using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoryLogic.Classes;
using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photory.Controllers
{
    //[Authorize]
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
        public ActionResult<IQueryable<Comment>> GetAllCommentsFromPhoto(string photoID)
        {
            try
            {
                var comments = userlogic.GetAllCommentsFromPhoto(photoID);
                return Ok(comments);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }


        [HttpGet("GetUserFromGroup/{userID}&{GroupID}")]

        public ActionResult<User> GetUserFromGroup(string userID, string GroupID)
        {

            try
            {
                var user = userlogic.GetUserFromGroup(userID, GroupID);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

    }
}
