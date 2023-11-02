using BlazorBootcamp.Models;

namespace BlazorBootcamp.Business.Repository
{
    public interface IProductPriceRepository
    {
        public Task<ProductPriceDTO> Create(ProductPriceDTO entity);
        public Task<ProductPriceDTO> Update(ProductPriceDTO entity);
        public Task<int> Delete(int id);
        public Task<ProductPriceDTO> Get(int id);
        public Task<IEnumerable<ProductPriceDTO>> GetAll(int? id = null);
    }
}