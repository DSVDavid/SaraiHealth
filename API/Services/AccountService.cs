using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class AccountService:IAccountService
    {
        IUserRepository _repo_user;
        public AccountService(IUserRepository repo_user)
        {
            this._repo_user = repo_user;
        }

        public Users loginUser(string email, string password)
        {
            return this._repo_user.loginUser(email, password);
        }
    }
}
