using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Users loginUser(string email, string password);

        Users findByEmail(string email);

        Users getUser(int id);

        void AddPatientsCaregiver(List<CaregiverToPatient> pats);

        List<CaregiverToPatient> GetCarePatients();

        UserPatient getUserPatient(int userId);

        void updateUser(Users u);

        void updateUserPatient(UserPatient u);

        void create(Users user);

        void deleteUser(int id);

        void deleteCaregiverPatients(int id);

        void deletePatientCaregivers(int id);

        void deleteUserPatient(int patientId);

        IQueryable<Users> getUsersForRole(int roleId);

        List<Roles> GetRoles();
    }
}
