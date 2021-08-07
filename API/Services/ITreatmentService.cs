using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ITreatmentService
    {

         Task<object> getPatientTreatment(int userId);

        Task<object> getPatientTreatment(int userId,DateTime date);
    }
}
