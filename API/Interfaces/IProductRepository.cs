using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(Guid productId);
        void AddProduct(Product product);
        void DeletableProduct(int productId);
        void UpdateProduct(Product product);
        Task<bool> SaveAllAsync();

    }
}
