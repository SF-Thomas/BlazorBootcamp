using BlazorBootcamp.Models;

namespace BlazorBootcamp.Business.Repository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDto> Create(CategoryDto category);
        public Task<CategoryDto> Update(CategoryDto category);
        public Task<int> Delete(int id);
        public Task<CategoryDto> Get(int id);
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}