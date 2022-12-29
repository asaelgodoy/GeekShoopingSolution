using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductServicee
    {
        private readonly HttpClient _client;
        private const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        async Task<IEnumerable<ProductModel>> IProductServicee.FindAllProducts()
        {
            var reponse = await _client.GetAsync(BasePath);
            return await reponse.ReadContentAs<List<ProductModel>>();

        }

        async Task<ProductModel> IProductServicee.FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        async Task<ProductModel> IProductServicee.CreateProduct(ProductModel product)
        {
            var responde = await _client.PostAsJson(BasePath, product);
            if (!responde.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong calling the API");
            }
            else
                return await responde.ReadContentAs<ProductModel>();
        }

        async Task<ProductModel> IProductServicee.UpdateProduct(ProductModel product)
        {
            var response = await _client.PutAsJson(BasePath, product);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong calling the API");
            }
            else
                return await response.ReadContentAs<ProductModel>();
        }

        async Task<bool> IProductServicee.DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong calling the API");
            }
            else
                return await response.ReadContentAs<bool>();
        }
    }
}
