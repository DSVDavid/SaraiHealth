using API.Models;
using API.Repositories;
using ViewModel;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace API.Services
{
    public class PatientDataConsumer : IConsumer<SensorData>
    {
        private readonly IPatientDataRepository _pdr;
        private readonly IHubContext<PatientAlertHub> _alertHub;
        public PatientDataConsumer(IPatientDataRepository patientDataRepository,
            IHubContext<PatientAlertHub> alertHub)
        {
            this._pdr = patientDataRepository;
            this._alertHub = alertHub;
        }
        public async Task Consume(ConsumeContext<SensorData> context)
        {
            var data = context.Message;
            var pd = new PatientData();

            DateTime d1 = new DateTime(data.start);
            DateTime d2 = new DateTime(data.end);
            TimeSpan ts = d2 - d1;

            var h =ts.TotalHours;
            var m = ts.TotalMinutes;
            var log = false;
            var message = "";

            if(data.activity== "Sleeping" && h > 7)
            {
                log = true;
                message = "Patient is sleeping too much";
               
            }else if (data.activity =="Leaving" && h > 5 )
            {
                log = true;
                message = "Patient is outside too much";
            }
            else if (data.activity == "Toileting" && m> 30)
            {
                log = true;
                message = "Patient is spending too much time at the bathroom";
            }

            if (log)
            {
                pd.Activity = data.activity;
                pd.Checked = false;
                pd.IdPatient = data.patient_id;

                await _alertHub.Clients.All.SendAsync("patient_alert",data.patient_id.ToString(), message);
                await _pdr.addPatientData(pd);
            }
        }
    }
}
