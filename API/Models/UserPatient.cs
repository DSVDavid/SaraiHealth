using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class UserPatient
    {
        public UserPatient()
        {
            PatientTreatment = new HashSet<PatientTreatment>();
        }

        public long Id { get; set; }
        public string MedicalRecord { get; set; }
        public long IdUser { get; set; }

        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<PatientTreatment> PatientTreatment { get; set; }
    }
}
