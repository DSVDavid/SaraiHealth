using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Treatment
    {
        public Treatment()
        {
            PatientTreatment = new HashSet<PatientTreatment>();
            TreatmentMedication = new HashSet<TreatmentMedication>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PatientTreatment> PatientTreatment { get; set; }
        public virtual ICollection<TreatmentMedication> TreatmentMedication { get; set; }
    }
}
