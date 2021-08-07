using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class PatientAlertHub : Hub
    {
        private readonly IHubContext<PatientAlertHub> _hubContext;
        public PatientAlertHub(IHubContext<PatientAlertHub> hubContext)
        {
            this._hubContext = hubContext;
        }
        public async Task SendAlert(string patient, string message)
        {
            await Clients.All.SendAsync("patient_alert","Patient " + patient, message);
        }
    }
}
