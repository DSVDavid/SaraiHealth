using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Controllers.DTOS;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "caregiver")]
    [ApiController]
    public class CaregiverController : ControllerBase
    {

        private readonly ICaregiverService _caregiverService;
       

        public CaregiverController(ICaregiverService caregiverService)
        {
            this._caregiverService = caregiverService;

        }

        [HttpGet]
        public ActionResult<List<PatientDTO>> GetPatients()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string my_email = identity.FindFirst(ClaimTypes.Email).Value;

            var c= this._caregiverService.GetCaregiver(my_email);

            return Ok(c.patients);
        }
    }
}
