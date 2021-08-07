using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.DTOS;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        public UsersController(IAccountService accountService, ITokenService tokenService)
        {
            this._accountService = accountService;
            this._tokenService = tokenService;
        }

       [HttpPost("treatment_login")]
       public ActionResult<long> GetUserTreatment(UserLoginDTO u)
        {
             var user = this._accountService.loginUser(u.email, u.password);

            if (user == null)
            {
                return BadRequest("Email or password invalid");
            }

            return user.Id;
        }

        [HttpPost("login")]
        public ActionResult<UserDTO> GetUser(UserLoginDTO u)
        {
          
            var user = this._accountService.loginUser(u.email, u.password);

            if (user == null)
            {
                return BadRequest("Email or password invalid");
            }

            return new UserDTO
            {
                email = user.Email,
                token = _tokenService.CreateToken(user)
            };
        }
    }
}
