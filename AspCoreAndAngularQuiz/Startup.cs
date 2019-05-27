using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.System;
using DataAccessLayer;
using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
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
		private readonly IHostingEnvironment _currentEnvironment;
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			_currentEnvironment = env;
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			InitMappers();

			var connectionString = "";

			if (_currentEnvironment.IsDevelopment())
				connectionString = Configuration.GetConnectionString("QuizDatabase-TST");

			if (_currentEnvironment.IsProduction())
			{
				// TODO: if Production get any connectionString
			}

			services.AddDbContext<Context>(options =>
			{
				options.UseSqlite(connectionString);
			});

			InitRepositories(services);

			InitUnitOfWork(services);

			InitServices(services);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
		}

		private void InitMappers()
		{
			MapperInitializer.InitMapper();
		}

		private void InitRepositories(IServiceCollection services)
		{
			services.AddTransient<IRepository<DataAccessLayer.Entities.Question>, QuestionRepository>();
			services.AddTransient<IRepository<DataAccessLayer.Entities.Player>, PlayerRepository>();
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


			if (_currentEnvironment.IsProduction())
			{
				app.UseDefaultFiles();
				app.UseStaticFiles();
			}

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
