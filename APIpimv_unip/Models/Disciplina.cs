using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CargaHora { get; set; }
        public string AreaAcademica { get; set; }
        public int IdPeriodo { get; set; }
        public Periodo Periodo { get; set; }
        public bool AtividadeDisciplina { get; set; }
        public IList<Aula> Aulas { get; set; } = new List<Aula>();
        public IList<Professor> Professores { get; set; } = new List<Professor>();

    }
}
