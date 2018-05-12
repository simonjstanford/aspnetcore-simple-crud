﻿namespace SimpleCrudSite.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TypeID { get; set; }
        public ProductType Type { get; set; }
    }
}