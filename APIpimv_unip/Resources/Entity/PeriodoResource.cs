using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Resources.Entity
{
    public class PeriodoResource
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
    }
}
