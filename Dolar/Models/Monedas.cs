using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolar.Models
{
    public  class Monedas
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        public bool ActivoDivisa { get; set; }
    }
}
