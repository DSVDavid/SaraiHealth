using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly sarai_healthContext _context;
        public MedicationRepository(sarai_healthContext context)
        {
            this._context = context;
        }

        public void CreateMedication(Medication med)
        {
            this._context.Medication.Add(med);
            this._context.SaveChanges();
        }

        

        public void DeleteMedication(Medication med)
        {
            this._context.Medication.Remove(med);
            this._context.SaveChanges();
        }

        public List<Medication> getAllMedications()
        {
            return this._context.Medication.ToList();
            
        }

        public Medication GetMedication(int id)
        {
            return this._context.Medication.Where(m => m.Id == id).FirstOrDefault();
        }

        public void UpdateMedication(Medication med)
        {
            this._context.Medication.Update(med);
            this._context.SaveChanges();
        }
    }
}
