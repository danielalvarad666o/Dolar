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

        public string? Nombre { get; set; } //mexico

        [MinLength(2)]
        [MaxLength(2)]
        public string? Img { get; set; } //mx //USD //

        public bool ActivoDivisa { get; set; }

        public bool monedabase { get; set; }


    }
}

