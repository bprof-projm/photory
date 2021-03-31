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
        ContentLogic ContentLogic;

        public ContentController(UserLogic userlogic, ContentLogic ContentLogic)
        {
            this.userlogic = userlogic;
            this.ContentLogic = ContentLogic;
        }

        [HttpGet("GetAllCommentsFromPhoto/{photoID}")]
        public ActionResult<IQueryable<Comment>> GetAllCommentsFromPhoto(string photoID)
        {
            try
            {
                var comments = ContentLogic.GetAllCommentsFromPhoto(photoID);
                return Ok(comments);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }





        [HttpGet("/GetAllGroup")]
        public ActionResult<IQueryable<Group>> GetAllGroup()
        {
            try
            {
                
                return Ok(ContentLogic.GetAllGroup());
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }



        [HttpGet("/GetOnePhoto/{photoid}")]
        public ActionResult<Photo> GetOnePhoto(string photoid)
        {
            try
            {

                return Ok(ContentLogic.GetOnePhoto(photoid));
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }



        [HttpGet("/GetPhotosFromGroup/{GroupID}")]
        public ActionResult<IQueryable<Photo>> GetPhotosFromGroup(string GroupID)
        {
            try
            {

                return Ok(ContentLogic.GetPhotosFromGroup(GroupID));
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
