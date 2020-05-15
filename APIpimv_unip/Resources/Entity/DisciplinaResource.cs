using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Resources.Entity
{
    public class DisciplinaResource
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CargaHora { get; set; }
        public string AreaAcademica { get; set; }
        public PeriodoResource Periodo { get; set; }
    }
}
