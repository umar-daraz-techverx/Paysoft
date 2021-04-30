using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Techverx.Paysoft.DataContext;
using Techverx.Paysoft.ProxyService;
using Techverx.Paysoft.Seeder;
using Techverx.Paysoft.Services;

namespace Techverx.Paysoft.Installers.Bootstrapper
{
	public static class Bootstrapper
	{
		public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
		{
			services.RegisterService();
			services.RegisterSwagger();
			services.RegisterDB(configuration);
			services.RegisterXMLFormater();
			return services;
		}

		public static IServiceCollection RegisterService(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddAutoMapper(typeof(Startup));
			services.AddScoped<IEmployeeService, EmployeeService>();
			services.AddScoped<IPaymentCallBackService, PaymentCallBackService>();
			services.AddScoped<IProxyService, ProxyService.ProxyService>();
			services.AddScoped<IPaymentService, PaymentService>();
			services.AddScoped<IPaymentRequestService, PaymentRequestService>();
			services.AddTransient<IDBSeeder, DBSeeder>();
			return services;
		}
		public static IServiceCollection RegisterSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo {Title = "PaymentSoft", Version = "v1"});
			});
			return services;
		}
		public static IServiceCollection RegisterXMLFormater(this IServiceCollection services)
		{
			services.AddMvcCore().AddXmlSerializerFormatters().AddApiExplorer();
			return services;
		}
		public static IServiceCollection RegisterDB(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(
					name: "AllowOrigin",
					builder =>
					{
						builder.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
			});
			services.AddDbContext<ContextClass>(x =>
				x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
		public static void RegisterApplicationsSwagger(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentSoft v1"));
		}
			
	}
}
