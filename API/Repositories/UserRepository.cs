using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private sarai_healthContext _context;
        public UserRepository(sarai_healthContext context)
        {
            this._context = context;
        }

        public IQueryable<Users> getUsersForRole(int roleId)
        {
            return this._context.Users.Where(u => u.RoleId == roleId);
        }

        public Users loginUser(string email, string password)
        {
            var user = this._context.Users.Include(u=>u.Role).Where(u => u.Email == email && u.Password == password).FirstOrDefault();

            return user;
        }

        public List<Roles> GetRoles()
        {
            return this._context.Roles.ToList();
        }

        public List<CaregiverToPatient> GetCarePatients()
        {
            return this._context.CaregiverToPatient.ToList();
        }

        public void create(Users user)
        {
            this._context.Add(user);
            this._context.SaveChanges();
        }

        public void deleteUser(int id)
        {
           var u= this._context.Users.Where(u => u.Id == id).FirstOrDefault();
            this._context.Remove(u);
            this._context.SaveChanges();
        }

        public void updateUser(Users u)
        {
            this._context.Users.Update(u);
            this._context.SaveChanges();
        }

        public void updateUserPatient(UserPatient u)
        {
            this._context.UserPatient.Update(u);
            this._context.SaveChanges();
        }

        public void deleteUserPatient(int patientId)
        {
            var userPatient = this._context.UserPatient.Where(p => p.IdUser == patientId).FirstOrDefault();
            this._context.UserPatient.Remove(userPatient);
            this._context.SaveChanges();
        }

        public Users getUser(int id)
        {
           return this._context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public UserPatient getUserPatient(int userId)
        {
            return this._context.UserPatient.Where(u => u.IdUser == userId).FirstOrDefault();
        }

        public Users findByEmail(string email)
        {
            return this._context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public void AddPatientsCaregiver(List<CaregiverToPatient> pats)
        {
            this._context.CaregiverToPatient.AddRange(pats);
            this._context.SaveChanges();
        }

        public void deleteCaregiverPatients(int id)
        {
            var pats = this._context.CaregiverToPatient.Where(p => p.IdCaregiver == id).ToList();

            this._context.RemoveRange(pats);
            this._context.SaveChanges();
        }

        public void deletePatientCaregivers(int id)
        {
            var cares = this._context.CaregiverToPatient.Where(c => c.IdPatient == id).ToList();

            this._context.RemoveRange(cares);
            this._context.SaveChanges();
        }
    }
}
