using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.DTOS
{
    public class MedicationDTO
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Dosage { get; set; }
        public string SideEffects { get; set; }
    }
}
