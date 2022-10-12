namespace SavingOps.Models
{
    public class Saving
    {
        [Key]
        public int SavingID { get; set; }
        [Required]
        public DateTime DateSubmitted { get; set; }
        [Required]
        public double Cost { get; set; }
    }
}
