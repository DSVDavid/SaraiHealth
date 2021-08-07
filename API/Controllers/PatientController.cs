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
    [Authorize(Roles = "patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientService _patientService;
        

        public PatientController(IPatientService patientService)
        {
            this._patientService = patientService;
           
        }

        [HttpGet]
        public ActionResult GetPatientAccountDetails()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string my_email= identity.FindFirst(ClaimTypes.Email).Value;

            var my_patient = this._patientService.GetAllPatients().Where(em => my_email == em.Email).FirstOrDefault();

            PatientDTO pdto = new PatientDTO();

            pdto.email = my_patient.Email;
            pdto.name = my_patient.Name;
            pdto.address = my_patient.Address;
            pdto.gender = my_patient.Gender;
            pdto.birthDate = (DateTime)my_patient.BirthDate;
            pdto.medicalRecord = my_patient.UserPatient.ElementAt(0).MedicalRecord;


            return Ok(pdto);
        }
    }
}
