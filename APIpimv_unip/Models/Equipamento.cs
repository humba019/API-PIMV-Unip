using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; } 
        public int IdSetor { get; set; }
        public Setor Setor { get; set; }
        public IList<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
    }
}
