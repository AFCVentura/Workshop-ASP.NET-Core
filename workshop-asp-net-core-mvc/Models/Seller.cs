using System.ComponentModel.DataAnnotations;

namespace workshop_asp_net_core_mvc.Models
{
    public class Seller
    {
        /* Basic attributes */
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size shoud be between {2} and {1} characters")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] To change date format
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        /* 1 Department */
        public Department Department { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        /* n Sales */
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        /* Constructors */
        public Seller() 
        {
        }

        public Seller(int id, string name, string email, DateTime birthdate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthdate;
            BaseSalary = baseSalary;
            Department = department;
        }

        /* Methods */

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        // LINQ is fantastic
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
