using BlazorBootcamp.Models;

namespace BlazorBootcamp.Business.Repository
{
	public interface IProductRepository
	{
		public Task<ProductDTO> Create(ProductDTO entity);
		public Task<ProductDTO> Update(ProductDTO entity);
		public Task<int> Delete(int id);
		public Task<ProductDTO> Get(int id);
		public Task<IEnumerable<ProductDTO>> GetAll();
	}
}