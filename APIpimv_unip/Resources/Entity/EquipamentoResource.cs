using APIpimv_unip.Models;

namespace APIpimv_unip.Resources
{
    public class EquipamentoResource
    {

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public SetorResource Setor { get; set; }

    }
}
