using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGM.ServicosAoCidadao.Application.Dto;
using SGM.ServicosAoCidadao.Core.Mediator;
using SGM.ServicosAoCidadao.Application.Commands;
using SGM.ServicosAoCidadao.Domain.Entities;
using SGM.ServicosAoCidadao.Domain.Interfaces.Repository;
using SGM.ServicosAoCidadao.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("/api/solicitacaoReparo")]
	public class SolicitarConcertoIluminacaoController : ControllerBase
	{
		private readonly IMediatorHandler _mediator;
		private readonly ISolicitacaoReparoRepository _solicitacaoReparoRepository;		
		private readonly IAspNetUser _user;
		private readonly IMapper _mapper;

		public SolicitarConcertoIluminacaoController(IMediatorHandler mediator, ISolicitacaoReparoRepository solicitacaoReparoRepository, IAspNetUser user, IMapper mapper)
		{
			_mediator = mediator;
			_solicitacaoReparoRepository = solicitacaoReparoRepository;
			_user = user;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> CriarSolicitacaoReparo([FromBody] SolicitarConcertoIluminacaoCommand command)
		{
			var result = await _mediator.Send(command);
			if (result.IsValid)			
				return await Task.FromResult(Ok(ResultDto<bool>.Success(result.IsValid)));			
			else
			{
				var errosEncontrados = result.Errors.Select(x => x.ErrorMessage);
				return await Task.FromResult(Ok(ResultDto<bool>.Error(errosEncontrados)));
			}			
		}

		[HttpGet]
		public async Task<IActionResult> ObterSolicitacaoReparo()
		{				
			var usuarioId = _user.ObterUserId();
			var isUsuario = _user.IsUsuario();
			var solicitacoes = await _solicitacaoReparoRepository.Find(x => (!isUsuario || isUsuario && x.UsuarioId == usuarioId) && x.TipoSolicitacao == TipoSolicitacaoEnum.ReparoIluminacaoPublica);
		
			var solicitacoesDto = _mapper.Map<IEnumerable<SolicitacaoReparo>, IEnumerable<SolicitarConcertoIluminacaoDto>>(solicitacoes);
			return await Task.FromResult(Ok(ResultDto<IEnumerable<SolicitarConcertoIluminacaoDto>>.Success(solicitacoesDto)));
		}

		[HttpGet("{id}")]
		public async Task<ResultDto<SolicitarConcertoIluminacaoDto>> ObterPorId(Guid id)
		{
			var solicitacao = await _solicitacaoReparoRepository.ObterPorId(id);
			var solicitacaoDto = _mapper.Map<SolicitacaoReparo, SolicitarConcertoIluminacaoDto>(solicitacao);
			
			return await Task.FromResult(ResultDto<SolicitarConcertoIluminacaoDto>.Success(solicitacaoDto));

		}

		[Authorize(Roles = "Administrador,Funcionário")]
		[HttpPut("{id}/iniciarAtendimento")]
		public async Task<IActionResult> IniciarAtendimento(Guid id)
		{
			var command = new IniciarAtendimentoSolicitacaoConcertoIluminacaoCommand() { SolicitacaoId = id };
			var result = await _mediator.Send(command);

			return await Task.FromResult(Ok(ResultDto<bool>.Success(result.IsValid)));
		}

		[Authorize(Roles = "Administrador,Funcionário")]
		[HttpPut("{id}/finalizarAtendimento")]
		public async Task<IActionResult> FinalizarAtendimento(Guid id)
		{
			var command = new FinalizarAtendimentoSolicitacaoConcertoIluminacaoCommand() { SolicitacaoId = id };
			var result = await _mediator.Send(command);

			return await Task.FromResult(Ok(ResultDto<bool>.Success(result.IsValid)));
		}

		[Authorize(Roles = "Administrador,Gerente")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteSolicitacaoConcertoIluminacaoCommand() { SolicitacaoId = id };
			var result = await _mediator.Send(command);

			return await Task.FromResult(Ok(ResultDto<bool>.Success(result.IsValid)));
		}
	}
}
