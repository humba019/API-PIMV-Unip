using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Models
{
    public class Periodo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public bool AtividadePeriodo { get; set; }
        public IList<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    }
}
