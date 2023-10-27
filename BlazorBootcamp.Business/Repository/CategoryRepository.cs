using AutoMapper;
using BlazorBootcamp.Business.Repository;
using BlazorBootcamp.DataAccess;
using BlazorBootcamp.DataAccess.Data;
using BlazorBootcamp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootcamp.Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto category)
        {
            var obj = _mapper.Map<CategoryDto, Category>(category);
            obj.CreatedDate = DateTime.Now;
            var addedEntity = _context.Categories.Add(obj);
            await _context.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDto>(addedEntity.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _context.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _context.Categories.Remove(obj);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDto> Get(int id)
        {
            var obj = await _context.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDto>(obj);
            }
            return new CategoryDto();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_context.Categories);
        }

        public async Task<CategoryDto> Update(CategoryDto category)
        {
            var objFromDb = await _context.Categories.FirstOrDefaultAsync(u => u.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                _context.Categories.Update(objFromDb);
                await _context.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDto>(objFromDb);
            }
            return category;

        }
    }
}