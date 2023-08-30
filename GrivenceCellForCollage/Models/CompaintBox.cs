using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GrivenceCellForCollage.Models
{
    public class CompaintBox
    {
        [Key]
        public int ComplaintId { get; set; }
        public string? Description { get; set; }
        public int Id { get; set; }
        public Register? regi { get; set; }
        public DateTime Time { get; set; }
        public string? status { get; set; }


    }
}
