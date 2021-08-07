using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class PatientTreatment
    {
        public long Id { get; set; }
        public long IdPatient { get; set; }
        public long IdTreatment { get; set; }

        public virtual UserPatient IdPatientNavigation { get; set; }
        public virtual Treatment IdTreatmentNavigation { get; set; }
    }
}
