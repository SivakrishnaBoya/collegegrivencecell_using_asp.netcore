using System.ComponentModel.DataAnnotations;

namespace GrivenceCellForCollage.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int DepartmentName { get; set; }

       
    }
}
