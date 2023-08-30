using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrivenceCellForCollage.Models
{
    public class Register
    {

        [Key]
        [ForeignKey("Users")]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public long MobileNumber { get; set; }
        [Required]
        public int BranchId { get; set; }
        public virtual List<Branch>? Branchs { get; set; }
        [Required]
        public int DepartmentId{ get;set; }
        [Required]
        public virtual List<Department>? Category { get; set; }
        [Required]

        public Users? User { get; set; }


    }
}
