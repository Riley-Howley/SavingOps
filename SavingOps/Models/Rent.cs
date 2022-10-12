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
        public double Cost { get; set; }
    }
}
