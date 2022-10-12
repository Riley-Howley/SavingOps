namespace SavingOps.Models
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        [Required]
        public string BillTitle { get; set; }
        [Required]
        public double Cost { get; set; }
    }
}
