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
    [Route("{GroupAdmin}")]
    public class GroupAdminController :ControllerBase
    {
        GroupAdminLogic groupAdminLogic;


        public GroupAdminController(GroupAdminLogic groupAdminLogic)
        {
            this.groupAdminLogic = groupAdminLogic;
        }


        [HttpPost]
        public void AddGroupAdmin([FromBody] User u)
        {
            groupAdminLogic.CreateGroupAdmin(u);
        
        }


        [HttpDelete("{id}")]
        public void DeleteGroupAdmin(string id)
        {

            groupAdminLogic.DeleteGroupAdmin(id);

        }

        [HttpGet]
        public IEnumerable<User> GetAllUser()
        {
            return groupAdminLogic.GetAllGroupAdmin();
        }


        [HttpGet("{id}")]
        public User GetGroupAdmin(string id)
        {
            return groupAdminLogic.GetGroupAdmin(id);
        }


        [HttpPut("{oldid}")]
        public void UpdateGroupAdmin(string oldid, [FromBody] User u)
        {
            groupAdminLogic.UpdateGroupAdmin(oldid, u);

        }

        [HttpPost("AcceptUser/{userID}&{GroupID}")]
        //[Route("AcceptUser")]
        //[ActionName("AcceptUser")]
        public void AcceptUser(string userID, string GroupID)
        {
            groupAdminLogic.AcceptUser(userID, GroupID);

        }



        [HttpPost("DenyUser/{userID}&{GroupID}")]
        //[Route("DenyUser")]
        //[ActionName("DenyUser")]
        public void DenyUser(string userID, string GroupID)
        {
            groupAdminLogic.DenyUser(userID, GroupID);

        }


    }
}
