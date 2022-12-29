using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductServicee
    {
        public Task<IEnumerable<ProductModel>> FindAllProducts();

        public Task<ProductModel> FindProductById(long id);

        public Task<ProductModel> CreateProduct(ProductModel product);

        public Task<ProductModel> UpdateProduct(ProductModel product);

        public Task<bool> DeleteProductById(long id);

    }
}
