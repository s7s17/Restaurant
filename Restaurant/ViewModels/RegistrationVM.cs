using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.ViewModels
{
    [NotMapped]
    public class RegistrationVM
    {

        [Key]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression("^(01[0-2]|015)[0-9]{8}$")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }


        [Range(0,100)]
        public byte Age { get; set; }
        public DateTime RegisterDate { get; set; }


    }
}
