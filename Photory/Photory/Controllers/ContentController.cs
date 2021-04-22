using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoryLogic.Classes;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Photory.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Content")]
    public class ContentController : ControllerBase
    {
        UserLogic userlogic;
        ContentLogic ContentLogic;
        IPhotoRepository photo;

        public ContentController(UserLogic userlogic, ContentLogic contentLogic, IPhotoRepository photo)
        {
            this.userlogic = userlogic;
            ContentLogic = contentLogic;
            this.photo = photo;
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


        [HttpGet("GetAllUser")]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            try
            {
                var users = userlogic.GetAllUser();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
        [HttpGet("PhotoDownload/{photoID}")]
        public FileResult Download(string photoID)
        {
            var p = photo.GetOnePhoto(photoID);
            var image = Image.Load(p.PhotoData);
            image.Mutate(x => x.Resize(p.Width, p.Height));
            var tmppath = Path.Combine(Environment.CurrentDirectory + @"\Photos",  p.PhotoTitle);
            image.Save(tmppath);

            var bytes = System.IO.File.ReadAllBytes(tmppath);
            System.IO.File.Delete(tmppath);
            return File(bytes, "application/octet-stream", $"{p.PhotoTitle}.jpg");
        }


    }
}
