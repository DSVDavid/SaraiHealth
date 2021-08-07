using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class TreatmentMedication
    {
        public long Id { get; set; }
        public long IdMedication { get; set; }
        public long IdTreatment { get; set; }
        public long? StartHour { get; set; }
        public long? EndHour { get; set; }
        public DateTime? TreatDate { get; set; }
        public bool? Taken { get; set; }

        public virtual Medication IdMedicationNavigation { get; set; }
        public virtual Treatment IdTreatmentNavigation { get; set; }
    }
}
