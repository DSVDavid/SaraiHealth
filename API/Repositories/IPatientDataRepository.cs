using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IPatientDataRepository
    {
        void checkDataForUser(int userId);

        List<PatientData> getPatientData(int patientId);

        Task  addPatientData(PatientData pd);
    }
}
