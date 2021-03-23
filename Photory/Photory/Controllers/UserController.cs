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
    [Authorize]
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        UserLogic userlogic;

        public UserController(UserLogic userlogic)
        {
            this.userlogic = userlogic;
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                userlogic.CreateUser(user);
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
                var users = userlogic.GetAllUser();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetOneUser(string id)
        {
            try
            {
                var user = userlogic.GetUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }

        [HttpPut("{oldid}")]

        public IActionResult UpdateUser(string oldid, [FromBody] User user)
        {
            try
            {
                userlogic.UpdateUser(oldid, user);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {          
            try
            {
                userlogic.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }

        }


        [HttpPost("{userID}&{GroupID}")]
        public IActionResult RequestJoin(string userID, string GroupID)
        { 
            try
            {
                userlogic.RequestJoin(userID, GroupID);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }

        }


        [HttpPost]
        [Route("AddPhoto")]
        public IActionResult AddPhoto([FromBody] Photo p)
        {  
            try
            {
                userlogic.AddPhoto(p);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }

        }

        [HttpDelete("DeletePhoto/{id}")]
        public IActionResult DeletePhoto(string id)
        {  
            try
            {
                userlogic.DeletePhoto(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }



        [HttpPost]
        [Route("AddComment")]
        public IActionResult AddComment([FromBody] Comment m)
        {
            try
            {
                userlogic.AddComment(m);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }



        [HttpDelete("DeleteComment/{id}")]
        public IActionResult DeleteComment(string id)
        {            
            try
            {
                userlogic.DeleteComment(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error : {ex}");
            }
        }





    }
}

