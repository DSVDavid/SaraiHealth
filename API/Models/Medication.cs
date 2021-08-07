using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Medication
    {
        public Medication()
        {
            TreatmentMedication = new HashSet<TreatmentMedication>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? Dosage { get; set; }
        public string SideEffects { get; set; }

        public virtual ICollection<TreatmentMedication> TreatmentMedication { get; set; }
    }
}
