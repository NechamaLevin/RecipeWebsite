using BLL.interfaces;
using DAL.functions;
using DAL.Interfaces;
using DAL.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BLL.models_bll;
using static BLL.functions.User_bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;


namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class UsersController : ControllerBase
    {
        Iuser_bll user;
        private readonly IConfiguration _configuration;

        public UsersController(Iuser_bll user, IConfiguration configuration)
        {
            this.user = user;
            _configuration = configuration;
        }

        [HttpGet("getUsers")]

        public ActionResult<List<User_modelBll>> GetAll()
        {
            return Ok(user.getall());

        }
        [HttpGet("getPermissions")]

        public ActionResult<List<LibrarianPermissionBll>> GetAllPermissions()
        {
            return Ok(user.GetPermissions());

        }
        [HttpPost("addUser")]
     
        public ActionResult<User_modelBll> add([FromForm] User_modelBll u)
        {
            return Ok(user.Add(u));
        }
        [HttpPut("updateUser")]
      
        public ActionResult<User_modelBll> update(User_modelBll u)
        {
            try
            {
                User_modelBll result = user.Update(u);
                return result;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete("dellUser/{id}")]
       
        public ActionResult<bool> dell(int id)
        {
            return Ok(user.Delete(id));
        }

        [HttpPut("reset-password")]

        public ActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            user.ResetPassword(request.UserId, request.NewPassword);
            return Ok(new { message = "Password reset successfully." });
        }
        [HttpGet("password-recovery/{email}")]

        public ActionResult<User> CheckEmail(string email)
        {
            return user.SendPasswordResetLink(email);


        }
        [HttpGet("password2/{email}")]

        public string SendEmail(string email)
        {
            return user.SendPassword2(email);


        }
        [HttpGet("AdminMail/{id}")]

        public User AdminEmail(int id)
        {
            return user.AdminPerrmisionLink(id);
        }

        [HttpGet("verify-security-questions")]
   
        public ActionResult VerifySecurityQuestions([FromQuery] string idNumber)
        {
            return Ok(user.VerifySecurityQuestions(idNumber));
        }
        [HttpPost("login")]

        public ActionResult<Response> getUser([FromBody] LoginInfo loginInfo)
        {
            return Ok(user.ValidateUser(loginInfo.tz, loginInfo.pass));
        }
       
        [HttpPut("{userId}/role")]

        public IActionResult UpdateUserRole(int userId, [FromBody] User_modelBll userDto)
        {
            var success = user.UpdateUserRole(userId, userDto.Role);
            if (success)
            {
                string newToken = user.GenerateJwtToken(user.getall().FirstOrDefault(u=>u.UserId==userId));

                return Ok(new { success = true, token = newToken });
            }
            else
            {
                return BadRequest(new { success = false, message = "Failed to update user role." });
            }
        }
        [HttpPost("validate-token")]

        public ActionResult<TokenValidationResponse> validToken([FromBody] string token)
        {
            return Ok(user.ValidateToken(token));
        }
        public class LoginInfo
        {
            public string tz { get; set; }
            public string pass { get; set; }
        }


        public class VerifySecurityQuestionsRequest
        {
            public string IdNumber { get; set; }
        }
        public class ResetPasswordRequest
        {
            public int UserId { get; set; }
            public string NewPassword { get; set; }
        }
        //[HttpGet("gmail-credentials")]
        //public ActionResult<GmailCredentials> GetGmailCredentials()
        //{
        //    string gmailAddress = _configuration["Gmail:Address"];
        //    string gmailPassword = _configuration["Gmail:Password"];
        //    return Ok(new GmailCredentials { Address = gmailAddress, Password = gmailPassword });
        //}

        public class GmailCredentials
        {
            public string Address { get; set; }
            public string Password { get; set; }
        }



    }
}

