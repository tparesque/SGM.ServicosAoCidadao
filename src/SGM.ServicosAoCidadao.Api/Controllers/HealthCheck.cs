using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Api.Controllers
{
	[ApiController]
	[Route("/api/servicos-ao-cidadao/health-check")]
	public class HealthCheck : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return Ok();
		}
	}
}
