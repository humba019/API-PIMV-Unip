using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
        public DateTime DataDevolucao { get; set; }
        public int IdEquipamento { get; set; }
        public Equipamento Equipamento { get; set; }
        public string Login { get; set; }
        public Usuario Usuario { get; set; }
        public string RelatorioDevolucao { get; set; }
        public bool AtividadeEmprestimo { get; set; }

    }
}
