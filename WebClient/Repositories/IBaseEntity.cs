using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Repositories
{
    public interface IBaseEntity
    {
        int ID { get; set; }
        DateTime RegisterDate { get; set; }
        DateTime MotificationDate { get; set; }
    }
}
