using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace API.Services
{
    public class PatientTreatmentHub:Hub
    {

         private readonly IHubContext<PatientTreatmentHub> _hubContext;
         private readonly ITreatmentService _treatService;
        private  IServiceProvider _serviceProvider;
        public PatientTreatmentHub(IServiceProvider serviceProvider,IHubContext<PatientTreatmentHub> hubContext,
                                    ITreatmentService treatService)
        {
            this._hubContext = hubContext;
            this._treatService = treatService;
            this._serviceProvider = serviceProvider;
            System.Diagnostics.Debug.WriteLine("writelineworks");
        }
        public async Task Treatment(string id)
        {


            int patientId = Int32.Parse(id);
         
            var treatment = await this._treatService.getPatientTreatment(patientId);
            await Clients.All.SendAsync("treatment", id);
            
               
        }
        
    }
}