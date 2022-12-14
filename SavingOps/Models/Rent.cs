global using System.ComponentModel.DataAnnotations;

namespace SavingOps.Models
{
    public class Rent
    {
        [Key]
        public int RentID { get; set; }
        [Required]
        public DateTime DateSubmitted { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double Cost { get; set; }
    }
}
