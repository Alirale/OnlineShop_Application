using Entities.DTOs;
using Entities.RepositoryInterfaces;
using Infrastructure.Repository;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductsCrudService
    {
        public Task<object> GetAllProducts();
        public Task<object> GetProduct(int id);
        public Task<object> Create(CreateProductDTO model);
        public Task<object> Edit(int id, CreateProductDTO model);
        public Task<object> Delete(int id);
        public Task<object> AddExtrasToProduct(int id, UpdateExtrasList updateExtrasList);
    }
    public class ProductsCrudService : IProductsCrudService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsCrudService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<object> GetAllProducts()
        {
            return await _productsRepository.GetAllProducts();
        }

        public async Task<object> GetProduct(int id)
        {
            var Product = await _productsRepository.GetAndShowProduct(id);
            return (Product);
        }

        public async Task<object> Create(CreateProductDTO model)
        {
            await _productsRepository.AddProduct(model);
            return $"Product Succesfully Added in Database";
        }

        public async Task<object> Edit(int id, CreateProductDTO NewProduct)
        {
            var ExistingProduct = await _productsRepository.GetProduct(id);
            await _productsRepository.EdiProduct(id, NewProduct, ExistingProduct);
            return $"Product Succesfully Eddited in Database";
        }

        public async Task<object> Delete(int id)
        {
            var Product = await _productsRepository.GetProduct(id);
            await _productsRepository.Delete(Product);
            return $"Product Succesfully Deleted From Database";
        }

        public async Task<object> AddExtrasToProduct(int id, UpdateExtrasList updateExtrasList)
        {
            var ExistingProduct = await _productsRepository.GetProduct(id);
            await _productsRepository.AddExtras(id, ExistingProduct, updateExtrasList);
            return $"Extras Succesfully Added to Product";
        }
    }
}
