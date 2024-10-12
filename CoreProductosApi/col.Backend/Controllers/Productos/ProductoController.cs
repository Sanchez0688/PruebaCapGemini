using col.Backend.UnitsOfWork.Interfaces.Productos;
using col.Shared.DTOs;
using col.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace col.Backend.Controllers.Productos
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductoController : ControllerBase
	{
		private readonly IProductoUnitOfWork _UnitOfWork;

		public ProductoController(IProductoUnitOfWork UnitOfWork)
		{
			_UnitOfWork = UnitOfWork;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> Get()
		{
			var result = await _UnitOfWork.Get();

			return StatusCode(result.CodigoHTTP, result);
		}

		[HttpGet("Get/{Id}")]
		public async Task<IActionResult> Get(int Id)
		{
			var result = await _UnitOfWork.Get(Id);

			return StatusCode(result.CodigoHTTP, result);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] ProductDTO Producto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Los datos proporcionados son inválidos.");
			}

			var result = await _UnitOfWork.Create(Producto);

			return StatusCode(result.CodigoHTTP, result);
		}

		[HttpPut("Update/{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] ProductDTO Producto)
		{
			if (id != Producto.Id)
			{
				return BadRequest("El ID del Producto no coincide.");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest("Los datos proporcionados son inválidos.");
			}

			var result = await _UnitOfWork.Update(Producto);

			return StatusCode(result.CodigoHTTP, result);
		}
		
		[HttpDelete("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _UnitOfWork.Delete(id);

			return StatusCode(result.CodigoHTTP, result);
		}

	}
}
