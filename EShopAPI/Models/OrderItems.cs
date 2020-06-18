using System.ComponentModel.DataAnnotations;


namespace EShopAPI.Models
{
    public partial class OrderItems : BaseEntity
    {

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public Orders Order { get; set; }

        public Product Product { get; set; }

    }
}
