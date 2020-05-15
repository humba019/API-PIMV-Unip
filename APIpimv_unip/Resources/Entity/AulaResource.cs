using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Resources.Entity
{
    public class AulaResource
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Andar { get; set; }
        public DisciplinaResource Disciplina { get; set; }
    }
}
