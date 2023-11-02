using AutoMapper;
using BlazorBootcamp.DataAccess.Data;
using BlazorBootcamp.DataAccess;
using BlazorBootcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorBootcamp.Business.Repository
{
	public class ProductPriceRepository : IProductPriceRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public ProductPriceRepository(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ProductPriceDTO> Create(ProductPriceDTO entity)
		{
			var obj = _mapper.Map<ProductPriceDTO, ProductPrice>(entity);
			var addedEntity = _context.ProductPrices.Add(obj);
			await _context.SaveChangesAsync();

			return _mapper.Map<ProductPrice, ProductPriceDTO>(addedEntity.Entity);
		}

		public async Task<int> Delete(int id)
		{
			var obj = await _context.ProductPrices.FirstOrDefaultAsync(u => u.Id == id);
			if (obj != null)
			{
				_context.ProductPrices.Remove(obj);
				return await _context.SaveChangesAsync();
			}
			return 0;
		}

		public async Task<ProductPriceDTO> Get(int id)
		{
			var obj = await _context.ProductPrices.FirstOrDefaultAsync(u => u.Id == id);
			if (obj != null)
			{
				return _mapper.Map<ProductPrice, ProductPriceDTO>(obj);
			}
			return new ProductPriceDTO();
		}

		public async Task<IEnumerable<ProductPriceDTO>> GetAll(int? id = null)
		{
			if (id != null && id != 0)
			{
				return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>(_context.ProductPrices.Where(p => p.ProductId == id));
			}
			else
			{
				return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>(_context.ProductPrices);
			}
		}

		public async Task<ProductPriceDTO> Update(ProductPriceDTO entity)
		{
			var objFromDb = await _context.ProductPrices.FirstOrDefaultAsync(u => u.Id == entity.Id);
			if (objFromDb != null)
			{
				objFromDb.ProductId = entity.ProductId;
				objFromDb.Size = entity.Size;
				objFromDb.Price = entity.Price;
				_context.ProductPrices.Update(objFromDb);
				await _context.SaveChangesAsync();
				return _mapper.Map<ProductPrice, ProductPriceDTO>(objFromDb);
			}
			return entity;

		}
	}
}
