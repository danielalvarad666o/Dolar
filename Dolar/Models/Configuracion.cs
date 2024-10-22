using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolar.Models
{
    public class Configuracion
    {
        [Key]
        public int Id { get; set; }

        public int? TipoCambioBaseId { get; set; }

        [ForeignKey("TipoCambioBaseId")]
        public TiposCambio? TipoCambioBase { get; set; }  // Relación con TiposCambio (opcional)
    }
}
