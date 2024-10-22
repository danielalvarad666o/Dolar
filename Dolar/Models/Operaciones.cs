using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolar.Models
{
    public class Operaciones
    {
        [Key]
        public int Id { get; set; }

        public int ConfiguracionId { get; set; }

        [ForeignKey("ConfiguracionId")]
        public Configuracion? Configuracion { get; set; }  // Relación con Configuración

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Monto { get; set; }  // Ejemplo de una propiedad adicional que representa un monto

        public DateTime FechaOperacion { get; set; }  // Fecha de la operación
    }
}
