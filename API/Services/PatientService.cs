using API.Controllers.DTOS;
using API.Models;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUserRepository _user_repo;
        public PatientService(IUserRepository user_repo)
        {
            this._user_repo = user_repo;
        }

        public void CreatePatient(PatientDTO patientDTO)
        { UserPatient up = new UserPatient();
            Users u = new Users();
            u.Name = patientDTO.name;
            u.Password = patientDTO.password;
            u.RoleId = 3;
            u.Email = patientDTO.email;
            u.Address = patientDTO.address;
            u.BirthDate = patientDTO.birthDate;
            u.Gender = patientDTO.gender;

            up.MedicalRecord = patientDTO.medicalRecord;
            u.UserPatient.Add(up);

            this._user_repo.create(u);
            
        }

        public void DeletePatient(int id)
        {
            this._user_repo.deleteUserPatient(id);
            this._user_repo.deletePatientCaregivers(id);
            this._user_repo.deleteUser(id);
        }

        public List<Users> GetAllPatients()
        {
           return _user_repo.getUsersForRole(3).Include(p => p.UserPatient).ToList();
        }

        

        public void UpdatePatient(PatientDTO patientDTO)
        {
            Users u = this._user_repo.getUser(patientDTO.id);
            UserPatient up = this._user_repo.getUserPatient(patientDTO.id);

            if (patientDTO.address!= null)
            {
                u.Address = patientDTO.address;
            }

            if (patientDTO.birthDate != null)
            {
                u.BirthDate = patientDTO.birthDate;
            }

            if (patientDTO.email != null)
            {
                u.Email = patientDTO.email;
            }

            if (patientDTO.gender != null)
            {
                u.Gender = patientDTO.gender;
            }

            if (patientDTO.password != null)
            {
                u.Password = patientDTO.password;
            }

            if (patientDTO.name != null)
            {
                u.Name = patientDTO.name;
            }

            if (patientDTO.medicalRecord != null)
            {
                up.MedicalRecord = patientDTO.medicalRecord;
            }

            this._user_repo.updateUser(u);
            this._user_repo.updateUserPatient(up);


        }
    }
}
