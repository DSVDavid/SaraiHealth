using API.Models;
using Microsoft.Extensions.Configuration;

namespace API.Services
{
    public interface ITokenService
    {
       
        string CreateToken(Users user);
    }
}
