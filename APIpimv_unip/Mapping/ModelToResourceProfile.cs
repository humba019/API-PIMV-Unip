using APIpimv_unip.Models;
using APIpimv_unip.Resources;
using APIpimv_unip.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIpimv_unip.Resources.Entity;

namespace APIpimv_unip.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Advertencia, AdvertenciaResource>();
            CreateMap<Aula, AulaResource>();
            CreateMap<Disciplina, DisciplinaResource>();
            CreateMap<Emprestimo, EmprestimoResource>();
            CreateMap<Equipamento, EquipamentoResource>();
            CreateMap<Periodo, PeriodoResource>();
            CreateMap<Professor, ProfessorResource>();
            CreateMap<Setor, SetorResource>();
            CreateMap<Usuario, UsuarioResource>();
        }
    }
}
