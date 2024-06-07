using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_DoListAppication.Models
{
    public class SignInModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Name is not empty. ")]
        [StringLength(100)]
        public string name { get; set; }
        [Required(ErrorMessage = "Email is not empty. ")]
        [StringLength(100)]
        public string email { get; set; }
       
        public long mobile { get; set; }
        [Required(ErrorMessage = "Please create a Strong Password ")]
        [StringLength(50)]
        public string password { get; set; }
        [StringLength(50)]
        [Compare("password",ErrorMessage ="password was not match.")]

        [Required(ErrorMessage = "password is not empty. ")]
        [NotMapped]
        public string re_password { get; set; }
    }
}
