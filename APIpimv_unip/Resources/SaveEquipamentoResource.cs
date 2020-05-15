using APIpimv_unip.Models;
using System.ComponentModel.DataAnnotations;

namespace APIpimv_unip.Resources
{
    public class SaveEquipamentoResource
    {
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public int IdSetor { get; set; }
    }
}
