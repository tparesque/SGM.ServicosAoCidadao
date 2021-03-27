using AutoMapper;
using SGM.ServicosAoCidadao.Domain.Entities;
using SGM.ServicosAoCidadao.Application.Dto;
using SGM.ServicosAoCidadao.Core.Enumerators;
using SGM.ServicosAoCidadao.Core.Util;

namespace SGM.ServicosAoCidadao.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<HistoricoSolicitacao, HistoricoSolicitacaoDto>()
                .ForMember(d => d.DataAlteracao, dto => dto.MapFrom(s => s.DataAlteracao.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(d => d.SituacaoNome, dto => dto.MapFrom(s => ((ESituacao)s.SituacaoId).GetDescription()));
            CreateMap<HistoricoSolicitacaoDto, HistoricoSolicitacao>();

            CreateMap<SolicitacaoReparo, SolicitarConcertoIluminacaoDto>()
                .ForMember(d => d.DataCadastro, dto => dto.MapFrom(s => s.DataCadastro.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(d => d.SituacaoNome, dto => dto.MapFrom(s => ((ESituacao)s.SituacaoId).GetDescription()));
            CreateMap<SolicitarConcertoIluminacaoDto, SolicitacaoReparo>();

            CreateMap<SolicitacaoIsencao, SolicitacaoIsencaoIptuDto>()
                .ForMember(d => d.Matricula, dto => dto.MapFrom(s => s.MatriculaImovel))
                .ForMember(d => d.DataCadastro, dto => dto.MapFrom(s => s.DataCadastro.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(d => d.SituacaoNome, dto => dto.MapFrom(s => ((ESituacao)s.SituacaoId).GetDescription()));

            CreateMap<SolicitacaoIsencaoIptuDto, SolicitacaoIsencao>();

        }
    }
}
