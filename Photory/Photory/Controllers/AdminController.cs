using Microsoft.AspNetCore.Mvc;
using PhotoryLogic.Classes;
using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photory.Controllers
{
    public class AdminController : ControllerBase
    {
        AdminLogic adminLogic;

        public AdminController(AdminLogic adminLogic)
        {
            this.adminLogic = adminLogic;
        }

        [HttpPost]
        public void AddAdmin([FromBody] User u)
        {
            adminLogic.CreateAdmin(u);
        }

        [HttpDelete("{id}")]
        public void DeleteAdmin(string id)
        {

            adminLogic.DeleteAdmin(id);
        }

        [HttpGet]
        public IEnumerable<User> GetAllAdmin()
        {
            return adminLogic.GetAllAdmin();
        }

        [HttpGet("{id}")]
        public User GetAdmin(string id)
        {
            return adminLogic.GetAdmin(id);
        }

        [HttpPut("{oldid}")]
        public void UpdateAdmin(string oldid, [FromBody] User u)
        {
            adminLogic.UpdateAdmin(oldid, u);
        }

        [HttpPost("AddMember/{userID}&{GroupID}")]
        public void AddMember(string userID, string GroupID)
        {
            adminLogic.AddMember(userID, GroupID);

        }

        [HttpPost]
        public void CreatGroup([FromBody] Group g)
        {
            adminLogic.CreateGroup(g);
        }
    }
}
