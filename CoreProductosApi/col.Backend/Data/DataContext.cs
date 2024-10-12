using col.Shared.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace col.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DisableCascadingDelete(modelBuilder);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        public async Task<(int newProductId, string message)> CallSPProductAsync(string SpName, Product data)
        {
            // Definir el parámetro de salida @Message
            var messageParam = new SqlParameter
            {
                ParameterName = "@Message",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 4000,
                Direction = System.Data.ParameterDirection.Output
            };

            // Definir el parámetro de retorno
            var returnValue = new SqlParameter
            {
                ParameterName = "@Value",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            // Ejecutar el SP
            if (SpName.Equals("SP_CREATE_PRODUCT"))
            {
                await Database.ExecuteSqlRawAsync(
                    "EXEC SP_CREATE_PRODUCT @Name, @Description, @Price, @Stock, @Message OUTPUT,@Value OUTPUT",
                        new SqlParameter("@Name", data.Name),
                        new SqlParameter("@Description", data.Description),
                        new SqlParameter("@Price", data.Price),
                        new SqlParameter("@Stock", data.Stock),
                    messageParam,
                    returnValue
                );
            }
            if (SpName.Equals("SP_UPDATE_PRODUCT"))
            {
                await Database.ExecuteSqlRawAsync(
                        "EXEC SP_UPDATE_PRODUCT @Id, @Name, @Description, @Price, @Stock, @Message OUTPUT,@Value OUTPUT",
                            new SqlParameter("@Id", data.Id),
                            new SqlParameter("@Name", data.Name),
                            new SqlParameter("@Description", data.Description),
                            new SqlParameter("@Price", data.Price),
                            new SqlParameter("@Stock", data.Stock),
                        messageParam,
                        returnValue
                        );
            }

            if (SpName.Equals("SP_DELETE_PRODUCT"))
            {
                await Database.ExecuteSqlRawAsync(
                        "EXEC SP_DELETE_PRODUCT @Id, @Message OUTPUT,@Value OUTPUT",
                            new SqlParameter("@Id", data.Id),
                            messageParam,
                            returnValue
                        );
            }

            // Capturar los valores de salida y retorno
            int newProductId = (int)returnValue.Value;
            string message = messageParam.Value.ToString();

            return (newProductId, message);
        }

    }
}
