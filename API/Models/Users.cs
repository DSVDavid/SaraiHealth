using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Users
    {
        public Users()
        {
            CaregiverToPatientIdCaregiverNavigation = new HashSet<CaregiverToPatient>();
            CaregiverToPatientIdPatientNavigation = new HashSet<CaregiverToPatient>();
            PatientData = new HashSet<PatientData>();
            UserPatient = new HashSet<UserPatient>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public long RoleId { get; set; }
        public string Password { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<CaregiverToPatient> CaregiverToPatientIdCaregiverNavigation { get; set; }
        public virtual ICollection<CaregiverToPatient> CaregiverToPatientIdPatientNavigation { get; set; }
        public virtual ICollection<PatientData> PatientData { get; set; }
        public virtual ICollection<UserPatient> UserPatient { get; set; }
    }
}
