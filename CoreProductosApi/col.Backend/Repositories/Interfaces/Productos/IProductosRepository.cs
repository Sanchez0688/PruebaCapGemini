using col.Shared.DTOs;
using col.Shared.Entities;
using col.Shared.Responses;

namespace col.Backend.Repositories.Interfaces.Productos
{
	public interface IProductosRepository
	{
		Task<ActionResponse<IEnumerable<Product>>> Get();
		Task<ActionResponse<Product>> Get(int id);
		Task<ActionResponse<string>> Create(ProductDTO Producto);
		Task<ActionResponse<string>> Update(ProductDTO Producto);
		Task<ActionResponse<string>> Delete(int id);
	}
}
