using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool AtividadeSetor { get; set; }
        public IList<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

    }
}
