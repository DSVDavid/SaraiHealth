using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.DTOS
{
    public class UserLoginDTO
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
