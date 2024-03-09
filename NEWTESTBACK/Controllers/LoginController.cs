using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEWTESTBACK.Models;

namespace NEWTESTBACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserContext _userContext;

        public LoginController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpPost]
        [Route("LoginUser")]
        public IActionResult PostLoginDetails(Users userData)
        {
            if (userData == null)
            {
                return BadRequest("No Data Posted");
            }

            var resultLoginCheck = _userContext.Users
                .FirstOrDefault(e => e.Username == userData.Username && e.Password == userData.Password);

            if (resultLoginCheck == null)
            {
                return BadRequest("Invalid Credentials");
            }
            else
            {
                userData.Username = "Login Success";
                return Ok(userData);
            }
        }
    }
}
