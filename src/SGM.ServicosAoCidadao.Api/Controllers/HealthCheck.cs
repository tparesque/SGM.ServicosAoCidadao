using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Runtime.Versioning;

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

		[HttpGet("/machine-name")]
		public IActionResult Informacoes()
		{
			return Json(new
			{
				Environment.MachineName,
				Sistema = Environment.OSVersion.VersionString,
				TargetFramework = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName
			});
		}
	}
}
