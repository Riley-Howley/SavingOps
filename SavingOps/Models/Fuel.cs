namespace SavingOps.Models
{
    public class Fuel
    {
        [Key]
        public int FuelID { get; set; }
        [Required]
        public DateTime FuelSubmitted { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double Cost { get; set; }
    }
}
