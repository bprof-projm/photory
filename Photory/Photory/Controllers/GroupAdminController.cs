using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoryLogic.Classes;
using PhotoryModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Photory.Controllers
{
    [Authorize(Roles = "GroupAdmin")]
    [ApiController]
    [Route("GroupAdmin")]
    public class GroupAdminController :ControllerBase
    {
        GroupAdminLogic groupAdminLogic;


        public GroupAdminController(GroupAdminLogic groupAdminLogic)
        {
            this.groupAdminLogic = groupAdminLogic;
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteGroupAdmin(string id)
        {
            try
            {
                groupAdminLogic.DeleteGroupAdmin(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }

        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            try
            {
                var groupadmins = groupAdminLogic.GetAllGroupAdmin();
                return Ok(groupadmins);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }


        [HttpGet("{id}")]
        public ActionResult<User> GetGroupAdmin(string id)
        {
            try
            {
                var groupadmin = groupAdminLogic.GetGroupAdmin(id);
                return Ok(groupadmin);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }


        [HttpPut("{oldid}")]
        public IActionResult UpdateGroupAdmin(string oldid, [FromBody] User u)
        {
            try
            {
                groupAdminLogic.UpdateGroupAdmin(oldid, u);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }

        }

        [HttpPost("AcceptUser/{userID}&{GroupID}")]
        public IActionResult AcceptUser(string userID, string GroupID)
        {
            try
            {
                groupAdminLogic.AcceptUser(userID, GroupID);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }

        }



        [HttpPost("DenyUser/{userID}&{GroupID}")]
        public IActionResult DenyUser(string userID, string GroupID)
        {
            try
            {
                groupAdminLogic.DenyUser(userID, GroupID);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }

        }



        [HttpPost("SetGroupPicture/{GroupID}"), DisableRequestSizeLimit]
        public IActionResult SetGroupPicture(IFormFile FileToUpload,string GroupID)
        {
            try
            {
                var folderName = "Photos";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (FileToUpload != null || FileToUpload.Length > 0)
                {
                    var fullpath = Path.Combine(pathToSave, FileToUpload.FileName);

                    using (var stream = new FileStream(fullpath, FileMode.Create))
                    {
                        FileToUpload.CopyTo(stream);
                    }
                    groupAdminLogic.SetGroupPicture(FileToUpload.FileName, GroupID);
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }

        }




    }
}
