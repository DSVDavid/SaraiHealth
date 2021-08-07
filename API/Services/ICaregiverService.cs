using API.Controllers.DTOS;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ICaregiverService
    {
        public List<CaregiverDTO> GetAllCaregivers();

        public void AddCaregiver(CaregiverDTO caregiver);

        public void UpdateCaregiver(CaregiverDTO caregiver);

        public void DeleteCaregiver(int id);

        public CaregiverDTO GetCaregiver(string email);

    }
}
