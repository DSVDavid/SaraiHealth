using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class PatientData
    {
        public long Id { get; set; }
        public long IdPatient { get; set; }
        public bool? Checked { get; set; }
        public string Activity { get; set; }

        public virtual Users IdPatientNavigation { get; set; }
    }
}
