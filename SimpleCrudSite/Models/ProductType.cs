using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrudSite.Models
{
    public class ProductType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public bool CanBeRemoved => Products.Any();
    }
}
