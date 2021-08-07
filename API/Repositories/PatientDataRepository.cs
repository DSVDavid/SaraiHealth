using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PatientDataRepository : IPatientDataRepository
    {
        private readonly sarai_healthContext _context;
        public  PatientDataRepository(sarai_healthContext context){
            this._context = context;
            }
        public async Task  addPatientData(PatientData pd)
        {
            await _context.PatientData.AddAsync(pd);
            await _context.SaveChangesAsync();
        }

        public void checkDataForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public List<PatientData> getPatientData(int patientId)
        {
            return this._context.PatientData.Where(p => p.IdPatient == patientId && p.Checked == false).ToList();
        }
    }
}
