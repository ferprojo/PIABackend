using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIA_Backend.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }

    }
}
