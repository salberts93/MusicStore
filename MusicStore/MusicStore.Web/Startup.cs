using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicStore.Core.Interfaces;
using MusicStore.Core.Services;
using MusicStore.Data;

namespace MusicStore.Web
{
	public class Startup
	{
		private IConfiguration Configuration;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Startup));
			services.AddControllers();
			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
			{
				builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
			}));

			services.AddDbContext<MusicStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			
			services.AddTransient<ISeeder, Seeder>();
			services.AddTransient<ISongRepository, SongRepository>();
			services.AddTransient<ISongService, SongService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeeder seeder)
		{
			if (env.IsDevelopment())
			{
				seeder.Seed();
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseCors("MyPolicy");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Hello World!");
				});
			});
		}
	}
}
