using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebClient.Repositories;

namespace WebClient.Models
{
    public class BaseEntity : IBaseEntity
    {
        public int ID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime MotificationDate { get; set; }
    }
}
