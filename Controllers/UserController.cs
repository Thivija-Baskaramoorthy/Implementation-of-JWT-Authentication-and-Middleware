using JWT_TokenBased.DTOs;
using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;
using JWT_TokenBased.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_TokenBased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
         

        // end points
        [HttpPost("save")]
        public ActionResult<BaseResponse> CreateUser(CreateUserRequest request)
        {
            // perform User model validation
            if (!ModelState.IsValid)
            {
                return BadRequest( ModelState);
            }
            return userService.CreateUser(request);
        }
    }
}
