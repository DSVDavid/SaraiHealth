using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories;

namespace API.Services
{
    public class TreatmentService : ITreatmentService
    {   
        public ITreatmentRepository _treatRepo;
        public TreatmentService(ITreatmentRepository treatRepo){
            this._treatRepo = treatRepo;
        }
        public async Task<object> getPatientTreatment(int userId)
        {
            var currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var myDate =  DateTime.Parse(currentDate);



            var treatment= await this._treatRepo.getTreamentPlan(userId);
            treatment.IdTreatmentNavigation.TreatmentMedication = treatment.IdTreatmentNavigation.TreatmentMedication.Where( pt => pt.TreatDate == myDate).ToList();

            return treatment;
        }

        public async Task<object> getPatientTreatment(int userId, DateTime date)
        {

            var treatment = await this._treatRepo.getTreamentPlan(userId);
            treatment.IdTreatmentNavigation.TreatmentMedication = treatment.IdTreatmentNavigation.TreatmentMedication.Where(pt => pt.TreatDate == date).ToList();

            return treatment;
        }
    }
}
