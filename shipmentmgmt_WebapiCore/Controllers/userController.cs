using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.BusinessLayer.Models;
using shipmentmgmt_WebapiCore.DataLayer;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shipmentmgmt_WebapiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly dataaccess _db;
        private readonly Iuser _userrepo;
        public userController(Iuser userrepo ,dataaccess dataaccess)
        {
            _userrepo = userrepo;
            _db = dataaccess;
        }

        // GET: api/<userController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{UserId},{Password}")]
        public IActionResult Login(string UserId, string Password)
        {
            // 1. Check Database for matching User + Password
            DataTable dt = _db.select("sp_crud_user", new SqlParameter[]
            {
                new SqlParameter("@UserId", UserId),
                new SqlParameter("@Password", Password),
                new SqlParameter("@action",4)
                // Note: You likely don't need "@Action" for sp_UserLogin unless you merged it into sp_ManageUser
            });
            // 2. Simple Check: Did we find a row?
            if (dt != null && dt.Rows.Count > 0)
            {
                // YES -> Login Success
                return Ok("Login Successful");
            }
            else
            {
                // NO -> Login Failed
                return Unauthorized("Invalid Username or Password");
            }
        }

        //// GET api/<userController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<userController>
        [HttpPost]
        public  IActionResult Post([FromBody] user users)
        {
            var reponse=  _userrepo.AddUser(users);
            if (reponse ==0)
                return Ok("user Register successfully");
            else
                return BadRequest("failed");
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          var respnse =  _userrepo.DeleteUser(id);
            if(respnse!=null)
            {
                return Ok("user deleted successfully");
            }
            else
                return BadRequest();
        }
    }
}
