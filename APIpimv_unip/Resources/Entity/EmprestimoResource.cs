using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Resources.Entity
{
    public class EmprestimoResource
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public EquipamentoResource Equipamento { get; set; }
        public UsuarioResource Usuario { get; set; }
    }
}
