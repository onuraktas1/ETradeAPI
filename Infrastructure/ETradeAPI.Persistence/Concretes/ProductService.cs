using ETradeAPI.Application.Abstractions;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        => new()
        {
            new(){ Id=Guid.NewGuid(),Name="Product 1",Price=250, Stock=20, CreatedDate=DateTime.Now},
            new(){ Id=Guid.NewGuid(),Name="Product 2",Price=450, Stock=40, CreatedDate=DateTime.Now},
            new(){ Id=Guid.NewGuid(),Name="Product 3",Price=550, Stock=60, CreatedDate=DateTime.Now},
            new(){ Id=Guid.NewGuid(),Name="Product 4",Price=650, Stock=220, CreatedDate=DateTime.Now},
            new(){ Id=Guid.NewGuid(),Name="Product 5",Price=750, Stock=50, CreatedDate=DateTime.Now},
        };
    }
}
