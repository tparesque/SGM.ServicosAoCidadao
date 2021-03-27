using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGM.ServicosAoCidadao.Application.Dto;
using SGM.ServicosAoCidadao.Core.Mediator;
using SGM.ServicosAoCidadao.Application.Commands;
using SGM.ServicosAoCidadao.Domain.Entities;
using SGM.ServicosAoCidadao.Domain.Interfaces.Repository;
using SGM.ServicosAoCidadao.Core.Enumerators;
using SGM.ServicosAoCidadao.Core.Usuario;
using SGM.ServicosAoCidadao.Core.Util;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace SGM.ServicosAoCidadao.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("/api/solicitacoes")]
	public class SolicitacaoIsencaoIptuController : ControllerBase
	{
		private readonly IMediatorHandler _mediator;
		private readonly IAspNetUser _user;
		private readonly ISolicitacaoIsencaoRepository _repository;
		private readonly IMapper _mapper;

		public SolicitacaoIsencaoIptuController(
			IMediatorHandler mediator,
			IAspNetUser user,
			ISolicitacaoIsencaoRepository repository,
			IMapper mapper)
		{
			_mediator = mediator;
			_user = user;
			_repository = repository;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> CriarSolicitacao([FromBody] SolicitarIsencaoIptuCommand command)
		{
			var result = await _mediator.Send(command);

			if (result.IsValid)
			{
				return await Task.FromResult(Ok(ResultDto<bool>.Success(result.IsValid)));
			}
			else
			{
				var errosEncontrados = result.Errors.Select(x => x.ErrorMessage);

				return await Task.FromResult(Ok(ResultDto<bool>.Error(errosEncontrados)));
			}
		}


		[HttpGet]
		public async Task<IActionResult> ObterSolicitacaoIsencao()
		{
			var usuarioId = _user.ObterUserId();
			var isUsuario = _user.IsUsuario();
			var solicitacoes = await _repository.Find(x => (!isUsuario || isUsuario && x.UsuarioId == usuarioId) && x.TipoSolicitacao == TipoSolicitacaoEnum.IsencaoIptu);
			var solicitacoesDto = PopularDadosSolicitacoesDto(solicitacoes);
			return await Task.FromResult(Ok(ResultDto<IEnumerable<SolicitacaoIsencaoIptuDto>>.Success(solicitacoesDto)));
		}

		[HttpGet("{id}")]
		public async Task<ResultDto<SolicitacaoIsencaoIptuDto>> ObterPorId(Guid id)
		{
			var solicitacao = await _repository.ObterPorId(id);
			var solicitacaoDto = _mapper.Map<SolicitacaoIsencao, SolicitacaoIsencaoIptuDto>(solicitacao);

			return await Task.FromResult(ResultDto<SolicitacaoIsencaoIptuDto>.Success(solicitacaoDto));

		}

		private IEnumerable<SolicitacaoIsencaoIptuDto> PopularDadosSolicitacoesDto(IEnumerable<SolicitacaoIsencao> solicitacoes)
		{
			var solicitacoesDto = new List<SolicitacaoIsencaoIptuDto>();

			foreach (var solicitacao in solicitacoes)
			{
				solicitacoesDto.Add(new SolicitacaoIsencaoIptuDto()
				{
					SolicitacaoId = solicitacao.SolicitacaoId,
					UsuarioId = solicitacao.UsuarioId,
					UsuarioNome = solicitacao.UsuarioNome,
					Observacao = solicitacao.Observacao,
					SituacaoId = solicitacao.SituacaoId,
					SituacaoNome = ((ESituacao)solicitacao.SituacaoId).GetDescription(),
					DataCadastro = solicitacao.DataCadastro.ToString("dd/MM/yyyy HH:mm"),
					Matricula = solicitacao.MatriculaImovel
				});
			}

			return solicitacoesDto;
		}

	}

}
