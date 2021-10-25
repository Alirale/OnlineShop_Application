using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entities.RepositoryInterfaces
{
    public interface IProductsRepository
    {
        public Task<List<ShowProducts>> GetAllProducts();
        public Task<ShowProducts> GetAndShowProduct(int id);
        public Task<Product> GetProduct(int id);
        public Task AddProduct(CreateProductDTO product);
        public Task EdiProduct(int Id, CreateProductDTO product, Product existingProduct);
        public Task Delete(Product product);
        public Task AddExtras(int id, Product ExistingProduct, UpdateExtrasList updateExtrasList);
    }
}
