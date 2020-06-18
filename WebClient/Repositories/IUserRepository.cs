using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Repositories
{
    interface IUserRepository : IGenericRepository<Users>
    {
        Task<Users> LoginUser(string name, string password);
    }
}
