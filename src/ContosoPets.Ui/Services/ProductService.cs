using ContosoPets.Ui.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoPets.Ui.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpointUrl;

        public ProductService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _endpointUrl = configuration["ProductServiceUrl"];
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await _httpClient.GetAsync($"{_endpointUrl}/api/products");
            response.EnsureSuccessStatusCode();

            var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();

            return products;
        }

        public async Task<Product> GetProductById(int productId)
        {
            var response = await _httpClient.GetAsync($"{_endpointUrl}/api/products/{productId}");
            response.EnsureSuccessStatusCode();

            var product = await response.Content.ReadAsAsync<Product>();

            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            await _httpClient.PutAsJsonAsync<Product>($"{_endpointUrl}/api/products/{product.Id}", product);
        }

        public async Task CreateProduct(Product product)
        {
            await _httpClient.PostAsJsonAsync<Product>($"{_endpointUrl}/api/products", product);
        }

        public async Task DeleteProduct(int productId)
        {
            await _httpClient.DeleteAsync($"{_endpointUrl}/api/products/{productId}");
        }
    }
}
