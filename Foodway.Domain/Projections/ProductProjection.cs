using Foodway.Domain.Entities;
using Foodway.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Domain.Projections
{
    public static class ProductProjection
    {
        public static IQueryable<ProductViewModel> ToViewModel(this IQueryable<Product> query) => query.Select(product => new ProductViewModel
        {
            Category = product.Category.ToViewModel(),
            Id = product.Id,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            Stock = new ProductStockViewModel()
            {
                Quantity = product.Stock.QuantityInStock,
                IsAvailable = product.Stock.IsAvailable
            }
        });

        public static IEnumerable<ProductViewModel> ToViewModel(this IEnumerable<Product> query) => query.Select(product => new ProductViewModel
        {
            Category = product.Category.ToViewModel(),
            Id = product.Id,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            Stock = new ProductStockViewModel()
            {
                Quantity = product.Stock.QuantityInStock,
                IsAvailable = product.Stock.IsAvailable
            }
        });

        public static ProductViewModel ToViewModel(this Product product) => new ProductViewModel
        {
            Category = product.Category.ToViewModel(),
            Id = product.Id,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            Stock = new ProductStockViewModel()
            {
                Quantity = product.Stock.QuantityInStock,
                IsAvailable = product.Stock.IsAvailable
            }
        };
    }
}
