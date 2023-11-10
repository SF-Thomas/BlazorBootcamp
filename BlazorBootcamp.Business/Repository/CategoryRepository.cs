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
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO entity)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(entity);
            obj.CreatedDate = DateTime.Now;
            var addedEntity = _context.Categories.Add(obj);
            await _context.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(addedEntity.Entity);
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

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _context.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_context.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO entity)
        {
            var objFromDb = await _context.Categories.FirstOrDefaultAsync(u => u.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = entity.Name;
                _context.Categories.Update(objFromDb);
                await _context.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return entity;

        }
    }
}