using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopAPI.Models
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int? ProductSize { get; set; }

        public string ProductVarienty { get; set; }

        [Required]
        public double? ProductPrice { get; set; }

        public string ProductStatus { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
