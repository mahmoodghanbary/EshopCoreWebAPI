using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace EShopAPI.Models
{
    public partial class SalesPerson : BaseEntity
    {
        public SalesPerson()
        {
            Orders = new HashSet<Orders>();
        }
        public string SpName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please fill your Email")]
        public string SpEmail { get; set; }

        public string SpPhone { get; set; }

        public string SpAddress { get; set; }

        public string SpCity { get; set; }

        public string SpState { get; set; }

        public string SpZipCode { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
