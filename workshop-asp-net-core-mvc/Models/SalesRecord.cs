using workshop_asp_net_core_mvc.Models.Enums;

namespace workshop_asp_net_core_mvc.Models
{
    public class SalesRecord
    {
        /* Basic attributes */
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        /* Enum */
        public SaleStatus Status { get; set; }
        /* 1 Seller */
        public Seller Seller { get; set; }

        /* Constructors */
        public SalesRecord() 
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
