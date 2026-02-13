using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.DataLayer;
using System.Data;
using System.Security.Claims;

namespace shipmentmgmt_WebapiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly dataaccess _db;
        private readonly Iuser _userrepo;
        private readonly ITokenService _tokenService;
        public AuthController(Iuser userrepo, dataaccess dataaccess, ITokenService tokenService)
        {
            _userrepo = userrepo;
            _db = dataaccess;
            _tokenService = tokenService;
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
            if (dt != null && dt.Rows.Count > 0)
            {
                var userRow = dt.Rows[0];

                // Create claims for the token
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, UserId),
                new Claim(ClaimTypes.NameIdentifier, UserId) 
                // Add roles if available: new Claim(ClaimTypes.Role, "Admin")
            };
                // Generate Token
                var accessToken = _tokenService.GenerateAccessToken(claims);
                return Ok(new
                {
                    Token = accessToken,
                    Message = "Login Successful"
                });
            }
            else
                return Unauthorized("Invalid Username or Password");
        }
    
    }
}
