using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolar.Models
{
    public class Empresas
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]

        public string? Nombre { get; set; } //mexico


        [MaxLength(50)]

        public string? Direccion { get; set; } //mexico


        [MaxLength(50)]

        public string? Estado { get; set; } //mexico



    }
}
