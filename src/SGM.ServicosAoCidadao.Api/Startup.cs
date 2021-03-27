using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SGM.ServicosAoCidadao.Api.Configurations;
using SGM.ServicosAoCidadao.Application.Mapper;
using SGM.ServicosAoCidadao.Repository.Context;
using SGM.WebAPI.Core.Autenticacao;
using SGM.WebAPI.Core.Middlewares;

namespace SGM.ServicosAoCidadao.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}		

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();	
			services.AddDbContext<ServicosAoCidadaoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddMessageBusConfiguration(Configuration);
			services.AddJwtConfiguration(Configuration);
			services.AddMediatR(typeof(Startup));
			services.AddDependencyInjection();
			services.AddAutoMapper(typeof(MappingProfile));
			services.AddSwaggerGenConfig();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())			
				app.UseDeveloperExceptionPage();

			app.UseSwaggerConfig();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthConfiguration();

			app.UseExceptionHandler(new ExceptionHandlerOptions
			{
				ExceptionHandler = new CustomExceptionMiddleware().Invoke
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
