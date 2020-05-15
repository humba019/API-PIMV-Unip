using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Resources.Entity
{
    public class ProfessorResource
    {
        public int Id { get; set; }
        public DisciplinaResource Disciplina { get; set; }
        public UsuarioResource Usuario { get; set; }
    }
}
