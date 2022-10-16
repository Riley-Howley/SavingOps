namespace SavingOps.Models
{
    public class AccountSettings
    {
        [Key]
        public int AccountSettingsID { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double RentPrice { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double SavingsGoal { get; set; }
    }
}
 