using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_DoListAppication.Models
{
    public class WorkRecordModel
    {
        [Key]
        public int workId {  get; set; }
        [Required(ErrorMessage = "Work Name is not empty. ")]
        [StringLength(100)]
        public string workName { get; set; }
        [Required(ErrorMessage = "Work Name is not empty. ")]
        [StringLength(300)]
        public string workDetails { get; set; }
        [StringLength(20)]
        public string IsCompleted { get; set; }
        [Required(ErrorMessage = "Please fill Task Date. ")]
        
        public DateTime? dateOfWork { get; set; }

        [ForeignKey("email")]
        [Required(ErrorMessage = "User email is not empty. ")]
        [StringLength(100)]
        public string userEmail { get; set; }
        
    }
}
