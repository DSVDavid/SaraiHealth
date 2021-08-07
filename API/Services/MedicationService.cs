using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _med_repo;
        public MedicationService(IMedicationRepository med_repo)
        {
            this._med_repo = med_repo;
        }

        public void CreateMedication(Medication med)
        {
            this._med_repo.CreateMedication(med);
        }

        public void DeleteMedication(int medId)
        {
            var med = this._med_repo.GetMedication(medId);
            this._med_repo.DeleteMedication(med);
        }

        public List<Medication> GetAllMedications()
        {
            return this._med_repo.getAllMedications();
        }

        public void UpdateMedication(Medication med)
        {
            var med1 = this._med_repo.GetMedication((int)med.Id);

            if (med.Name != null)
            {
                med1.Name = med.Name;
            }

            if (med.Dosage != null)
            {
                med1.Dosage = med.Dosage;
            }

            if (med.SideEffects != null)
            {
                med1.SideEffects = med.SideEffects;
            }

            this._med_repo.UpdateMedication(med1);
        }
    }
}
