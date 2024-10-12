using col.Backend.Data;
using col.Backend.Repositories.Interfaces.Productos;
using col.Shared.DTOs;
using col.Shared.Entities;
using col.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace col.Backend.Repositories.Implementations.Productos
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly DataContext _context;
        public ProductosRepository(DataContext dfcontext)
        {
            _context = dfcontext;
        }

        public async Task<ActionResponse<string>> Create(ProductDTO ProductoDTO)
        {
            var actionResponse = new ActionResponse<string>();

            try
            {
                // Verificar si ya existe un Producto con el mismo TipoDocumento y NumeroDocumento
                var ProductoExistente = await _context.Product
                    .AnyAsync(x => x.Name == ProductoDTO.Name);

                if (ProductoExistente)
                {
                    actionResponse.Result = "Producto ya se encuentra registrado.";
                    actionResponse.WasSuccess = false;
                    actionResponse.Message = "Producto ya se encuentra registrado.";
                    actionResponse.CodigoHTTP = 409; // Conflict
                }
                else
                {
                    // Convertir ProductoDTO a Producto
                    var product = new Product
                    {
                        Name = ProductoDTO.Name,
                        Description = ProductoDTO.Description,
                        Price = ProductoDTO.Price,
                        Stock = ProductoDTO.Stock
                    };

                    var resposeSP = await _context.CallSPProductAsync("SP_CREATE_PRODUCT", product);
                    if (resposeSP.newProductId > 0)
                    {
                        actionResponse.Result = resposeSP.newProductId.ToString();
                        actionResponse.WasSuccess = true;
                        actionResponse.Message = resposeSP.message;
                        actionResponse.CodigoHTTP = 201; // Created}
                    }
                    else
                    {
                        actionResponse.Result = resposeSP.newProductId.ToString();
                        actionResponse.WasSuccess = false;
                        actionResponse.Message = resposeSP.message;
                        actionResponse.CodigoHTTP = 400; // Created}
                    }
                }
            }
            catch (Exception ex)
            {
                actionResponse.WasSuccess = false;
                actionResponse.Message = $"Error al crear el Producto: {ex.Message}";
                actionResponse.CodigoHTTP = 500; // Internal Server Error
            }

            return actionResponse;
        }


        public async Task<ActionResponse<Product>> Get(int id)
        {
            ActionResponse<Product> actionResponse = new();
            try
            {
                actionResponse.Result = await _context.Product.FindAsync(id);

                actionResponse.WasSuccess = true;

                actionResponse.CodigoHTTP = 200;
                if (actionResponse.Result == null)
                {
                    actionResponse.Message = "No se encontro el Producto.";
                    actionResponse.CodigoHTTP = 404;
                }

            }
            catch (Exception ex)
            {
                actionResponse.WasSuccess = false;
                actionResponse.Message = $"Ocurrió un error al ejecutar la consulta";
                actionResponse.CodigoHTTP = 500;
            }
            return actionResponse;
        }

        public async Task<ActionResponse<string>> Update(ProductDTO ProductoDTO)
        {
            var actionResponse = new ActionResponse<string>();

            try
            {
                var existingProducto = await _context.Product.FindAsync(ProductoDTO.Id);

                if (existingProducto == null)
                {
                    actionResponse.WasSuccess = false;
                    actionResponse.Message = "Producto no encontrado.";
                    actionResponse.CodigoHTTP = 404; // Not Found
                    return actionResponse;
                }

                existingProducto.Name = ProductoDTO.Name;
                existingProducto.Description = ProductoDTO.Description;
                existingProducto.Stock = ProductoDTO.Stock;
                existingProducto.Price = ProductoDTO.Price;


                var resposeSP = await _context.CallSPProductAsync("SP_UPDATE_PRODUCT", existingProducto);
                if (resposeSP.newProductId > 0)
                {
                    actionResponse.Result = resposeSP.newProductId.ToString();
                    actionResponse.WasSuccess = true;
                    actionResponse.Message = resposeSP.message;
                    actionResponse.CodigoHTTP = 200; // Created}
                }
                else
                {
                    actionResponse.Result = resposeSP.newProductId.ToString();
                    actionResponse.WasSuccess = false;
                    actionResponse.Message = resposeSP.message;
                    actionResponse.CodigoHTTP = 400; // Created}
                }
            }
            catch (Exception ex)
            {
                actionResponse.WasSuccess = false;
                actionResponse.Message = $"Error al actualizar el Producto: {ex.Message}";
                actionResponse.CodigoHTTP = 500; // Internal Server Error
            }

            return actionResponse;
        }


        public async Task<ActionResponse<string>> Delete(int id)
        {
            var actionResponse = new ActionResponse<string>();

            try
            {
    
                var existingProducto = await _context.Product.FindAsync(id);

                if (existingProducto == null)
                {
                    actionResponse.WasSuccess = false;
                    actionResponse.Message = "Producto no encontrado.";
                    actionResponse.CodigoHTTP = 404; // Not Found
                    return actionResponse;
                }

                var resposeSP = await _context.CallSPProductAsync("SP_DELETE_PRODUCT", existingProducto);
                if (resposeSP.newProductId == 0)
                {
                    actionResponse.Result = resposeSP.newProductId.ToString();
                    actionResponse.WasSuccess = true;
                    actionResponse.Message = resposeSP.message;
                    actionResponse.CodigoHTTP = 200; // Created}
                }
                else
                {
                    actionResponse.Result = resposeSP.newProductId.ToString();
                    actionResponse.WasSuccess = false;
                    actionResponse.Message = resposeSP.message;
                    actionResponse.CodigoHTTP = 400; // Created}
                }

            }
            catch (Exception ex)
            {
                actionResponse.WasSuccess = false;
                actionResponse.Message = $"Error al eliminar el Producto: {ex.Message}";
                actionResponse.CodigoHTTP = 500; // Internal Server Error
            }

            return actionResponse;
        }
        public async Task<ActionResponse<IEnumerable<Product>>> Get()
        {
            ActionResponse<IEnumerable<Product>> actionResponse = new();

            try
            {

                actionResponse.Result = await _context.Product.ToListAsync();
                actionResponse.WasSuccess = true;

                actionResponse.CodigoHTTP = 200;
                if (actionResponse.Result.Count() == 0)
                {
                    actionResponse.Message = "No se encontraron Productos.";
                    actionResponse.CodigoHTTP = 404;
                }

            }
            catch (Exception ex)
            {
                actionResponse.WasSuccess = false;
                actionResponse.Message = $"Ocurrió un error al ejecutar la consulta";
                actionResponse.CodigoHTTP = 500;
            }
            return actionResponse;
        }



    }
}
