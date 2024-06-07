using System.ComponentModel.DataAnnotations;

namespace To_DoListAppication.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Enter UserID")]
        public string? email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string? password { get; set; }
    }
}
