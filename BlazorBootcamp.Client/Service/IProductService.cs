using BlazorBootcamp.Models;

namespace BlazorBootcamp.Client.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> Get(int productId);

    }
}
