using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Model
{
    public class RequestModelDemo
    {
        [Required(ErrorMessage = "Please Enter the Password")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter the Password")]
        public string password { get; set; }
    }
}
