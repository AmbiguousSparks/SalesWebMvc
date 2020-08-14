using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Areas.Departments.Models;
using SalesWebMVC.Areas.SalesRecords.Models;
using SalesWebMVC.Areas.SalesRecords.Models.Enums;
using SalesWebMVC.Areas.Sellers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;
        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // Já está populado
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
                return;
            Department department = new Department(1, "Computers");
            Department department2 = new Department(2, "Electronics");
            Department department3 = new Department(3, "Fashion");
            Department department4 = new Department(4, "Books");
            Department department5 = new Department(5, "Food");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, department);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, department2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, department);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, department4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, department3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, department2);

            ICollection<SalesRecord> salesRecords = new List<SalesRecord>()
            {
                new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1),
                new SalesRecord(2, new DateTime(2018, 09, 4), 7000.0, SaleStatus.Billed, s5),
                new SalesRecord(3, new DateTime(2018, 09, 13), 4000.0, SaleStatus.Canceled, s4),
                new SalesRecord(4, new DateTime(2018, 09, 1), 8000.0, SaleStatus.Billed, s1),
                new SalesRecord(5, new DateTime(2018, 09, 21), 3000.0, SaleStatus.Billed, s3),
                new SalesRecord(6, new DateTime(2018, 09, 15), 2000.0, SaleStatus.Billed, s1),
                new SalesRecord(7, new DateTime(2018, 09, 28), 13000.0, SaleStatus.Billed, s2),
                new SalesRecord(8, new DateTime(2018, 09, 11), 4000.0, SaleStatus.Billed, s4),
                new SalesRecord(9, new DateTime(2018, 09, 14), 11000.0, SaleStatus.Pending, s6),
                new SalesRecord(10, new DateTime(2018, 09, 7), 9000.0, SaleStatus.Billed, s6),
                new SalesRecord(11, new DateTime(2018, 09, 13), 6000.0, SaleStatus.Billed, s2),
                new SalesRecord(12, new DateTime(2018, 09, 25), 7000.0, SaleStatus.Pending, s3),
                new SalesRecord(13, new DateTime(2018, 09, 29), 10000.0, SaleStatus.Billed, s4),
                new SalesRecord(14, new DateTime(2018, 09, 4), 3000.0, SaleStatus.Billed, s5),
                new SalesRecord(15, new DateTime(2018, 09, 12), 4000.0, SaleStatus.Billed, s1),
                new SalesRecord(16, new DateTime(2018, 10, 5), 2000.0, SaleStatus.Billed, s4),
                new SalesRecord(17, new DateTime(2018, 10, 1), 12000.0, SaleStatus.Billed, s1),
                new SalesRecord(18, new DateTime(2018, 10, 24), 6000.0, SaleStatus.Billed, s3),
                new SalesRecord(19, new DateTime(2018, 10, 22), 8000.0, SaleStatus.Billed, s5),
                new SalesRecord(20, new DateTime(2018, 10, 15), 8000.0, SaleStatus.Billed, s6),
                new SalesRecord(21, new DateTime(2018, 10, 17), 9000.0, SaleStatus.Billed, s2),
                new SalesRecord(22, new DateTime(2018, 10, 24), 4000.0, SaleStatus.Billed, s4),
                new SalesRecord(23, new DateTime(2018, 10, 19), 11000.0, SaleStatus.Canceled, s2),
                new SalesRecord(24, new DateTime(2018, 10, 12), 8000.0, SaleStatus.Billed, s5),
                new SalesRecord(25, new DateTime(2018, 10, 31), 7000.0, SaleStatus.Billed, s3),
                new SalesRecord(26, new DateTime(2018, 10, 6), 5000.0, SaleStatus.Billed, s4),
                new SalesRecord(27, new DateTime(2018, 10, 13), 9000.0, SaleStatus.Pending, s1),
                new SalesRecord(28, new DateTime(2018, 10, 7), 4000.0, SaleStatus.Billed, s3),
                new SalesRecord(29, new DateTime(2018, 10, 23), 12000.0, SaleStatus.Billed, s5),
                new SalesRecord(30, new DateTime(2018, 10, 12), 5000.0, SaleStatus.Billed, s2)
            };

            _context.Department.AddRange(department, department2, department3, department4, department5);
            using(var transaction = _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Department ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Department OFF");
                _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Seller ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Seller OFF");
                _context.SalesRecord.AddRange(salesRecords);
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT SalesRecord ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT SalesRecord OFF");
                transaction.Commit();
            }
        }
    }
}
