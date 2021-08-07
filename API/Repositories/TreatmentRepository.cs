using System;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class TreatmentRepository: ITreatmentRepository
    {
        private readonly sarai_healthContext _context;
        public TreatmentRepository(sarai_healthContext context)
        {
            this._context = context;
        }

        public async Task<PatientTreatment> getTreamentPlan(int userId)
        {
           var treatmentPlanInfo = await this._context.PatientTreatment.Include(pt => pt.IdTreatmentNavigation).Include(pt => pt.IdTreatmentNavigation.TreatmentMedication).Where( pt => pt.IdPatient == userId).FirstOrDefaultAsync();

           if(treatmentPlanInfo==null){
               return null;
           }

            return treatmentPlanInfo;
           
        }


        public object getTreatments(DateTime date1){

            // var treatment = this._context.Treatment

            return null;
        }
    }

}