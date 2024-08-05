namespace workshop_asp_net_core_mvc.Models
{
    public class Department
    {
        /* Basic attributes */
        public int Id { get; set; }
        public string Name { get; set; }
        /* n Sellers */
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        /* Constructors */
        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /* Methods */

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(sr => sr.TotalSales(initial, final));
        }
    }
}
