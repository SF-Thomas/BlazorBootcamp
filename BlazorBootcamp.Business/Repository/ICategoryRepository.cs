using BlazorBootcamp.Models;

namespace BlazorBootcamp.Business.Repository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDTO> Create(CategoryDTO entity);
        public Task<CategoryDTO> Update(CategoryDTO entity);
        public Task<int> Delete(int id);
        public Task<CategoryDTO> Get(int id);
        public Task<IEnumerable<CategoryDTO>> GetAll();
    }
}