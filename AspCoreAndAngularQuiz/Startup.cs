using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using BusinessLogic.Services;
using BusinessLogic.System;
using DataAccessLayer;
using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspCoreAndAngularQuiz
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			MapperInitializer.InitMapper();

			services.AddDbContext<Context>(options => 
				options.UseSqlite(Configuration.GetConnectionString("QuizDatabase")));

			InitUnitOfWork(services);

			InitServices(services);

			InitLogic(services);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
		}

		private void InitLogic(IServiceCollection services)
		{
			services.AddTransient<IBlClass, BlClass>();
		}

		private void InitServices(IServiceCollection services)
		{
			services.AddTransient<IQuestionService, QuestionService>();
		}

		private void InitUnitOfWork(IServiceCollection services)
		{
			services.AddTransient<IUnitOfWork, UnitOfWork>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}
	}
}
