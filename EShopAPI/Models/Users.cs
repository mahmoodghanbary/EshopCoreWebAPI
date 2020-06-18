using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopAPI.Models
{
    public partial class Users : BaseEntity
    {
      public Users()
        {
            Orders = new HashSet<Orders>();
        }


        [Required(ErrorMessage = "Please fill your Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please fill your Email")] 
        public string UserEmail { get; set; }


        [DataType(DataType.Password)]
        [MaxLength(200)]
        [Required(ErrorMessage = "please fill password")]
        public string UserPassword { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(200)]
        [Required(ErrorMessage = "please fill Confirm Password")]
        [Compare("UserPassword", ErrorMessage = "password doesn't match")]
        public string UserConfirmPassword { get; set; }

        public int UserPhone { get; set; }

        public string UserAddress { get; set; }

        public string UserActiveCode { get; set; }

        public bool UserIsActive { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
