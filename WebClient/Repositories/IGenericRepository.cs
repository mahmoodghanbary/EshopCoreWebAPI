using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Repositories
{
    interface IGenericRepository<T>
    {
        List<T> GetAll(string token);
        T GetbyId(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);

    }
}
