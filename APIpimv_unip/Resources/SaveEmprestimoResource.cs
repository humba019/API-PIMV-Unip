using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Resources
{
    public class SaveEmprestimoResource
    {
        [Required]
        public int IdEquipamento { get; set; }
        [Required]
        public string Login { get; set; }
    }
}
