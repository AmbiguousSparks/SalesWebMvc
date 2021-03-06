﻿using SalesWebMvc.Areas.Departments.Models;
using System;
using System.Collections.Generic;
using SalesWebMVC.Areas.SalesRecords.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Areas.Sellers.Models
{
    public class Seller
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        #endregion

        #region Constructors
        public Seller()
        {
        }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }
        #endregion

        #region Methods
        public void AddSales(SalesRecord sr) => Sales.Add(sr);
        public void RemoveSales(SalesRecord sr) => Sales.Remove(sr);
        public double TotalSales(DateTime initial, DateTime final) => Sales.Where(s => s.Date >= initial && s.Date <= final).Sum(sr => sr.Amount); 
        #endregion
    }
}
