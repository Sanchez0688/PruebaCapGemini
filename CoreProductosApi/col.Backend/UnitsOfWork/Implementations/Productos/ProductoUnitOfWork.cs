using col.Backend.Repositories.Interfaces.Productos;
using col.Backend.UnitsOfWork.Interfaces.Productos;
using col.Shared.DTOs;
using col.Shared.Entities;
using col.Shared.Responses;

namespace col.Backend.UnitsOfWork.Implementations.Productos
{
	public class ProductoUnitOfWork : IProductoUnitOfWork
	{
		private readonly IProductosRepository _Repository;

		public ProductoUnitOfWork(IProductosRepository Repository)
		{
			_Repository = Repository;
		}

		public async Task<ActionResponse<string>> Create(ProductDTO Producto) => await _Repository.Create(Producto);

		public async Task<ActionResponse<string>> Delete(int id) => await _Repository.Delete(id);

		public async Task<ActionResponse<IEnumerable<Product>>> Get() => await _Repository.Get();
		public async Task<ActionResponse<Product>> Get(int id) => await _Repository.Get(id);

		public async Task<ActionResponse<string>> Update(ProductDTO Producto) => await _Repository.Update(Producto);
	}
}
