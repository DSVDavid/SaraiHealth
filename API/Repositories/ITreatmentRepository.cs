using System;
using System.Threading.Tasks;
using API.Models;

namespace API.Repositories
{
    public interface ITreatmentRepository
    {
         Task<PatientTreatment> getTreamentPlan(int userId);
        // public object getTreatments(DateTime date1);
    }

}