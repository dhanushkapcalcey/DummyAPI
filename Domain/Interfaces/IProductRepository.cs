using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(Guid productId);
        void AddProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task<bool> UpdateProduct(Guid productId, Product newProduct);
        Task<bool> SaveAllAsync();
    }
}
