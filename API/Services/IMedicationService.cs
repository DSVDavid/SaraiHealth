using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMedicationService
    {
        List<Medication> GetAllMedications();

        void CreateMedication(Medication med);


        void UpdateMedication(Medication med);

        void DeleteMedication(int medId);
    }
}
