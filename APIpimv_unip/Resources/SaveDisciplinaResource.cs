using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Resources
{
    public class SaveDisciplinaResource
    {
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
        [Required]
        public int Andar { get; set; }
        [Required]
        public int IdDisciplina { get; set; }
        [Required]
        public string CargaHora { get; set; }
        [Required]
        public string AreaAcademica { get; set; }
        [Required]
        public int IdPeriodo { get; set; }
    }
}
