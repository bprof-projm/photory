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
    [Route("Admin")]
    public class AdminController : ControllerBase
    {
        AdminLogic adminLogic;

        public AdminController(AdminLogic adminLogic)
        {
            this.adminLogic = adminLogic;
        }
        [HttpPost]
        public void CreateAdmin([FromBody] User user)
        {
            adminLogic.CreateAdmin(user);
        }
        [HttpDelete("{id}")]
        public void DeleteGroupAdmin(string id)
        {

            adminLogic.DeleteAdmin(id);

        }

        [HttpGet]
        public IEnumerable<User> GetAllAdmin()
        {
            return adminLogic.GetAllUser();
        }

        [HttpGet("{id}")]
        public User GetGroupAdmin(string id)
        {
            return adminLogic.GetAdmin(id);
        }

        [HttpPut("{oldid}")]

        public void UpdateUser(string oldid, [FromBody] User user)
        {
            adminLogic.UpdateAdmin(oldid, user);
        }


        [HttpPost("{userID}&{GroupID}")]
        public void AddMembers(string userID, string GroupID)
        {
            adminLogic.AddMember(userID, GroupID);

        }

        [HttpPost("/CreateGroup")]
        public void CreateGroup([FromBody] Group group)
        {
            adminLogic.CreateGroup(group);
        }
    }
}
