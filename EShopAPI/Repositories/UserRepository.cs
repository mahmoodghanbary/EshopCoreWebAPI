using System.Threading.Tasks;
using EShopAPI.Models;
using EShopAPI.Contracts;
using EShopAPI.Context;
using Microsoft.Extensions.Caching.Memory;

namespace EShopAPI.Repositories
{
    public class UserRepository: AsyncGenericRepository<Users>, IUserRepository
    {
        public UserRepository(EShopAPI_DBContext context, IMemoryCache cache) : base(context, cache) {}

        //public Task<Users> Login(string username, string pssword)
        //{
        //    return context.Set<Users>().FirstOrDefaultAsync(u => u.UserName.Contains(username) && u.UserPassword == pssword);
        //}

        public Task<Users> Login(string username, string pssword)
            => FirstOrDefault(u => u.UserName.Contains(username) && u.UserPassword == pssword);


        //private EShopAPI_DBContext _context;

        //public UserRepository(EShopAPI_DBContext context)
        //{
        //    _context = context;
        //}
        //public async Task<Users> Create(Users users)
        //{
        //    _context.Add(users);
        //    await _context.SaveChangesAsync();
        //    return users;
        //}

        //public async Task<Users> Delete(int id)
        //{
        //    var user = await _context.Product.SingleAsync(p => p.ID == id);
        //    _context.Product.Remove(user);
        //    await _context.SaveChangesAsync();
        //    return user;
        //}

        //public IEnumerable<Users> GetAll()
        //{
        //    return _context.Users.ToList();
        //}

        //public async Task<Users> GetbyId(int id)
        //{
        //    return await _context.Users.SingleOrDefaultAsync(p => p.ID == id);
        //}

        //public async Task<bool> IsExists(int id)
        //{
        //    return await _context.Users.AnyAsync(p => p.ID == id);
        //}

        //public async Task<Users> Update(Users users)
        //{
        //    _context.Product.Update(users);
        //    await _context.SaveChangesAsync();
        //    return users;
        //}


    }
}
