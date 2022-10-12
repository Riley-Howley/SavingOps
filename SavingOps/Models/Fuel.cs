namespace SavingOps.Models
{
    public class Fuel
    {
        [Key]
        public int FuelID { get; set; }
        [Required]
        public DateTime FuelSubmitted { get; set; }
        [Required]
        public double Cost { get; set; }
    }
}
