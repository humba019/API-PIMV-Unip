using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Models
{
    public class Advertencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Nivel { get; set; }
    }
}
