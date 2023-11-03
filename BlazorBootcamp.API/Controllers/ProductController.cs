using BlazorBootcamp.Business.Repository;
using BlazorBootcamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace BlazorBootcamp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
        {
			_productRepository = productRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _productRepository.GetAll());
		}

		[HttpGet("{productId}")]
		public async Task<IActionResult> Get(int? productId)
		{
			if(productId == null || productId == 0) 
			{
				return BadRequest(
					new ErrorModelDTO 
					{
						StatusCode = StatusCodes.Status400BadRequest,
						ErrorMessage = "Invalid Id"
					});
			}

			var product = await _productRepository.Get(productId.Value);

			if(product == null) 
			{
				return BadRequest(
					new ErrorModelDTO
					{
						StatusCode = StatusCodes.Status404NotFound,
						ErrorMessage = "Invalid Id"
					});
			}

			return Ok(product);
		}
	}
}
