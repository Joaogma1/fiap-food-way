using Foodway.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Domain.Entities
{
    public class Order : BaseAuditableEntity
    {
        public Guid Id { get; set; }

        public Client? Client { get; set; }

        public Guid? ClientId { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string? OrderCode { get; set; }
        
        public decimal Total => OrderItems.Sum(item => item.Quantity * item.Product.Price);

    }
}
