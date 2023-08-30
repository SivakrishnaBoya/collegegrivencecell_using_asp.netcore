using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GrivenceCellForCollage.Models
{
   
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
       


    }
}
