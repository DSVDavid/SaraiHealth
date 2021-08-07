using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(IPatientService patientService, ITreatmentService treatmentService)
        {
            this._patientService = patientService;
            this._treatmentService = treatmentService;

        }

        [HttpGet("{id}/{date}")]
        public object GetPatientTreatment(int id, DateTime date)
        {
            var treat = this._treatmentService.getPatientTreatment(id,date);

            return treat;
        }
    }
}
