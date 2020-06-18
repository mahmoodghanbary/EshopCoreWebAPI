using System;
using System.Collections.Generic;

namespace EShopAPI.Models
{
    public partial class Orders : BaseEntity
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }
        public DateTime? OrderDate { get; set; }

        public double? OrderTotal { get; set; }

        public string OrderStatus { get; set; }

        public int? UserId { get; set; }

        public int? SalesPersonId { get; set; }

        public Users Users { get; set; }

        public SalesPerson SalesPerson { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
