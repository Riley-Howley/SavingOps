namespace SavingOps.Models
{
    public class ListModel
    {
        public IList<Saving>? SavingList { get; set; }
        public IList<Rent>? RentList { get; set; }
        public IList<Fuel>? FuelList { get; set; }
        public IList<Bill>? BillList { get; set; }
        public IList<AccountSettings>? AccountList { get; set; }
    }
}
