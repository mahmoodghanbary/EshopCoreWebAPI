using System;
using EShopAPI.Contracts;
using System.ComponentModel.DataAnnotations;

namespace EShopAPI.Models
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime MotificationDate { get; set; }
    }
}
