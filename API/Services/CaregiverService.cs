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
    public class CaregiverService : ICaregiverService
    {
        private readonly IUserRepository _user_repo;
        public CaregiverService(IUserRepository user_repo)
        {
            this._user_repo = user_repo;
        }

        public void AddCaregiver(CaregiverDTO caregiver)
        {
            Users u = new Users();
            u.Name = caregiver.name;
            u.Address = caregiver.address;
            u.BirthDate = caregiver.birthDate;
            u.Email = caregiver.email;
            u.Password = caregiver.password;
            u.Gender = caregiver.gender;
            u.RoleId = 2;
            this._user_repo.create(u);

            var myUser = this._user_repo.findByEmail(u.Email);

            List<CaregiverToPatient> my_patients = new List<CaregiverToPatient>();

            caregiver.patients.ForEach(p =>
            {
                CaregiverToPatient my_patient = new CaregiverToPatient();
                my_patient.IdPatient = p.id;
                my_patient.IdCaregiver = myUser.Id;

                my_patients.Add(my_patient);
            });

            this._user_repo.AddPatientsCaregiver(my_patients);
            
        }

        public void DeleteCaregiver(int id)
        {
            this._user_repo.deleteCaregiverPatients(id);

            this._user_repo.deleteUser(id);
        }

        public List<CaregiverDTO> GetAllCaregivers()
        {
            List<CaregiverDTO> caregivers = new List<CaregiverDTO>();
            var care_givers = this._user_repo.getUsersForRole(2).ToList();

            var patients = this._user_repo.getUsersForRole(3).Include(p => p.UserPatient).ToList();

           

            var carePatients = this._user_repo.GetCarePatients();
            
            care_givers.ForEach(c =>
            {
                CaregiverDTO c1 = new CaregiverDTO();
                c1.id = (int)c.Id;
                c1.address = c.Address;
                c1.email = c.Email;
                c1.name = c.Name;
                c1.gender = c.Gender;
                c1.password = c.Password;
                c1.birthDate = (DateTime)c.BirthDate;

                var myPatients = carePatients.Where(cp => cp.IdCaregiver == c1.id).ToList();
                var myPatientsData = patients.Where(p => myPatients.Any(p1 => p1.IdPatient == p.Id)).ToList();

                List<PatientDTO> patientsForCaregiver = new List<PatientDTO>();
                myPatientsData.ForEach(p =>
               {
                   PatientDTO p1 = new PatientDTO();
                   p1.id = (int)p.Id;
                   p1.gender = p.Gender;
                   p1.name = p.Name;

                   patientsForCaregiver.Add(p1);
               });


                c1.patients = patientsForCaregiver;

                caregivers.Add(c1);
            });

            return caregivers;
            
        }

        public void UpdateCaregiver(CaregiverDTO caregiver)
        {
            var user = this._user_repo.getUser(caregiver.id);

            user.BirthDate = caregiver.birthDate;
            user.Address = caregiver.address;
            user.Email = caregiver.email;
            user.Gender = caregiver.gender;
            user.Name = caregiver.name;
            user.Password = caregiver.password;

            List<CaregiverToPatient> ctp = new List<CaregiverToPatient>();

            this._user_repo.updateUser(user);

            caregiver.patients.ForEach(p =>
           {
               CaregiverToPatient cp = new CaregiverToPatient();
               cp.IdPatient = p.id;
               cp.IdCaregiver = user.Id;
               ctp.Add(cp);
           });

            this._user_repo.deleteCaregiverPatients((int)user.Id);
            this._user_repo.AddPatientsCaregiver(ctp);

        }

        public CaregiverDTO GetCaregiver(string email)
        {
            var c = this._user_repo.findByEmail(email);

            CaregiverDTO c1 = new CaregiverDTO();
            c1.id = (int)c.Id;
            c1.address = c.Address;
            c1.email = c.Email;
            c1.name = c.Name;
            c1.gender = c.Gender;
            c1.password = c.Password;
            c1.birthDate = (DateTime)c.BirthDate;

            var patients = this._user_repo.getUsersForRole(3).Include(p => p.UserPatient).ToList();
            var carePatients = this._user_repo.GetCarePatients();

            var myPatients = carePatients.Where(cp => cp.IdCaregiver == c1.id).ToList();
            var myPatientsData = patients.Where(p => myPatients.Any(p1 => p1.IdPatient == p.Id)).ToList();

            List<PatientDTO> patientsForCaregiver = new List<PatientDTO>();

            myPatientsData.ForEach(p =>
            {
                PatientDTO p1 = new PatientDTO();
                p1.id = (int)p.Id;
                p1.gender = p.Gender;
                p1.name = p.Name;
                p1.email = p.Email;
                p1.address = p.Address;
                p1.birthDate = (DateTime)p.BirthDate;
                p1.medicalRecord = p.UserPatient.ElementAt(0).MedicalRecord;

                patientsForCaregiver.Add(p1);
            });

            c1.patients = patientsForCaregiver;

            return c1;
        }

        
    }
}
