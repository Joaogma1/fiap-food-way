using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Domain.Entities
{
    public class ProductStock
    {
        public Guid Id { get; set; }
        public required Product Product { get; set; }
        public required Guid ProductId { get; set; }
        public int QuantityInStock { get; set; }
        
        public bool IsAvailable => this.QuantityInStock > 0;
    }
}
