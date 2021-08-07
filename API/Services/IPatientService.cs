using API.Controllers.DTOS;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IPatientService
    {
        public void CreatePatient(PatientDTO patientDTO);

        public void UpdatePatient(PatientDTO patientDTO);

        public void DeletePatient(int id);

        public List<Users> GetAllPatients();

       
    }
}
