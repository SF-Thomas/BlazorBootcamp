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
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public ProductRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ProductDTO> Create(ProductDTO entity)
		{
			var obj = _mapper.Map<ProductDTO, Product>(entity);
			var addedEntity = _context.Products.Add(obj);
			await _context.SaveChangesAsync();

			return _mapper.Map<Product, ProductDTO>(addedEntity.Entity);
		}

		public async Task<int> Delete(int id)
		{
			var obj = await _context.Products.FirstOrDefaultAsync(u => u.Id == id);
			if (obj != null)
			{
				_context.Products.Remove(obj);
				return await _context.SaveChangesAsync();
			}
			return 0;
		}

		public async Task<ProductDTO> Get(int id)
		{
			var obj = await _context.Products
				.Include(p => p.Category)
				.Include(p => p.ProductPrices)
				.FirstOrDefaultAsync(u => u.Id == id);
			if (obj != null)
			{
				return _mapper.Map<Product, ProductDTO>(obj);
			}
			return new ProductDTO();
		}

		public async Task<IEnumerable<ProductDTO>> GetAll()
		{
			return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(
				_context.Products.Include(p => p.Category).Include(p => p.ProductPrices));
		}

		public async Task<ProductDTO> Update(ProductDTO entity)
		{
			var objFromDb = await _context.Products.FirstOrDefaultAsync(u => u.Id == entity.Id);
			if (objFromDb != null)
			{
				objFromDb.Name = entity.Name;
				objFromDb.Description = entity.Description;
				objFromDb.ImageUrl = entity.ImageUrl;
				objFromDb.CategoryId = entity.CategoryId;
				objFromDb.Color = entity.Color;
				objFromDb.ShopFavorites = entity.ShopFavorites;
				objFromDb.CustomerFavorites = entity.CustomerFavorites;
				_context.Products.Update(objFromDb);
				await _context.SaveChangesAsync();
				return _mapper.Map<Product, ProductDTO>(objFromDb);
			}
			return entity;

		}
	}
}