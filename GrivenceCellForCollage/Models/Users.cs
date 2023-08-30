using System.ComponentModel.DataAnnotations;

namespace GrivenceCellForCollage.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        
        public Register? register { get; set; }
        public int DepartmentId { get; set; }
        [Required]
        public List<Department>? Category { get; set; }

    }
}
