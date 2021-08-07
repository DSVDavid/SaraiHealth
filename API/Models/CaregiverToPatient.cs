using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CaregiverToPatient
    {
        public long Id { get; set; }
        public long IdPatient { get; set; }
        public long IdCaregiver { get; set; }

        public virtual Users IdCaregiverNavigation { get; set; }
        public virtual Users IdPatientNavigation { get; set; }
    }
}
