using System;

namespace EShopAPI.Contracts
{
   public interface IBaseEntity
    {
         int ID { get; set; }
         DateTime RegisterDate { get; set; }
         DateTime MotificationDate { get; set; }
    }
}
