
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace col.Shared.Entities
{
    [Table("Product")] // Nombre de la tabla en la BD
    public class Product
    {
        [Key] // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autoincrementable
        public int Id { get; set; }

        [Required] // Campo obligatorio
        [StringLength(100)] // Longitud máxima de 100 caracteres
        public string Name { get; set; }

        [StringLength(500)] // Longitud máxima de 500 caracteres para la descripción
        public string Description { get; set; }

        [Required] // Campo obligatorio
        [Column(TypeName = "decimal(18,2)")] // Define la precisión para el tipo decimal
        public decimal Price { get; set; }

        [Required] // Campo obligatorio
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer.")] // Restricción de rango para el stock
        public int Stock { get; set; }
    }
}
