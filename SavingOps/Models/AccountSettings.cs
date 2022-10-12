namespace SavingOps.Models
{
    public class AccountSettings
    {
        [Key]
        public int AccountSettingsID { get; set; }
        [Required]
        public double RentPrice { get; set; }
        [Required]
        public double SavingsGoal { get; set; }
    }
}
