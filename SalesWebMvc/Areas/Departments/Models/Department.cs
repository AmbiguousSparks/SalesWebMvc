using SalesWebMVC.Areas.Sellers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SalesWebMvc.Areas.Departments.Models
{
    public class Department
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); 
        #endregion

        #region Constructors
        public Department()
        {
        }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        } 
        #endregion

        #region Methods
        public void AddSeller(Seller seller) => Sellers.Add(seller);
        public void RemoveSeller(Seller seller) => Sellers.Remove(seller);
        public void TotalSales(DateTime initial, DateTime final) => Sellers.Sum(seller => seller.TotalSales(initial, final)); 
        #endregion
    }
}
