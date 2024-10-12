using col.Shared.DTOs;
using col.Shared.Entities;
using col.Shared.Responses;

namespace col.Backend.UnitsOfWork.Interfaces.Productos
{
	public interface IProductoUnitOfWork
	{
		Task<ActionResponse<IEnumerable<Product>>> Get();
		Task<ActionResponse<Product>> Get(int id);
		Task<ActionResponse<string>> Create(ProductDTO Producto);
		Task<ActionResponse<string>> Update(ProductDTO Producto);
		Task<ActionResponse<string>> Delete(int id);
	}
}
