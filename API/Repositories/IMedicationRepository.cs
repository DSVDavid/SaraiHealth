using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IMedicationRepository
    {
        List<Medication> getAllMedications();
        Medication GetMedication(int id);

        void UpdateMedication(Medication med);

        void DeleteMedication(Medication med);

        void CreateMedication(Medication med);
    }
}
