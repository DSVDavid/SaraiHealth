using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PatientAlertHubController: ControllerBase
    {
        private IHubContext<PatientAlertHub> patientAlertHub;
        public PatientAlertHubController(IHubContext<PatientAlertHub> patientAlertHub)
        {
            this.patientAlertHub = patientAlertHub;
        }
    }
}
