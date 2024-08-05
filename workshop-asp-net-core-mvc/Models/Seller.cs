﻿using System;

namespace workshop_asp_net_core_mvc.Models
{
    public class Seller
    {
        /* Basic attributes */
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public double BaseSalary { get; set; }
        /* 1 Department */
        public Department Department { get; set; }
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
            Birthdate = birthdate;
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
