using APIpimv_unip.Models;
using APIpimv_unip.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAdvertenciaResource, Advertencia>();
            CreateMap<SaveAulaResource, Aula>();
            CreateMap<SaveDisciplinaResource, Disciplina>();
            CreateMap<SaveEmprestimoResource, Emprestimo>();
            CreateMap<SaveEquipamentoResource, Equipamento>();
            CreateMap<SavePeriodoResource, Periodo>();
            CreateMap<SaveProfessorResource, Professor>();
            CreateMap<SaveSetorResource, Setor>();
            CreateMap<SaveUsuarioResource, Usuario>();
        }
    }
}
