﻿using SalesWebMVC.Areas.SalesRecords.Models.Enums;
using SalesWebMVC.Areas.Sellers.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Areas.SalesRecords.Models
{
    public class SalesRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
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
