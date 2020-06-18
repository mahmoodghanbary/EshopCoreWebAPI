using System.Threading.Tasks;
using EShopAPI.Models;

namespace EShopAPI.Contracts
{
   public interface IUserRepository: IAsyncGenericRepository<Users>
    {
        Task<Users> Login(string username, string pssword);
    }
}
