namespace SavingOps.Models
{
    public class Saving
    {
        [Key]
        public int SavingID { get; set; }
        [Required]
        public DateTime DateSubmitted { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double Cost { get; set; }
    }
}
