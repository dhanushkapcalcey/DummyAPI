using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void DeletableProduct(int productId);
        void UpdateProduct(Product product);
        Task<bool> SaveAllAsync();

    }
}
