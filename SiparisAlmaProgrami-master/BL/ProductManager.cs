using Entities;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class ProductManager : Repository<Product>
    {
        public List<ProductListDto> GetProducts()
        {
            var products = context.Products.Include("Category")
                .Select(x => new ProductListDto
                {
                    CategoryName = x.Category.Name,
                    Name = x.Name,
                    CreateDate = x.CreateDate,
                    IsActive = x.IsActive,
                    Price = x.Price,
                    Stock = x.Stock
                })
                .ToList();
            return products;
        }
    }
}
