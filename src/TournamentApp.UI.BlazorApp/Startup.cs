using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TournamentApp.UI.BlazorApp.ApiService.Code;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.Data;

namespace TournamentApp.UI.BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddHttpClient<IApiTournamentService, ApiTournamentService>(client => client.BaseAddress = new Uri("https://localhost:44336/api/tournaments/")) ;
            services.AddHttpClient<IApiTournamentRoundService, ApiTournamentRoundService>(client => client.BaseAddress = new Uri("https://localhost:44336/api/tournaments/")) ;
            services.AddHttpClient<IApiPlayerService, ApiPlayerService>(client => client.BaseAddress = new Uri("https://localhost:44336/api/players/")) ;
            services.AddHttpClient<IApiRoundService, ApiRoundService>(client => client.BaseAddress = new Uri("https://localhost:44336/api/rounds/")) ;
            services.AddHttpClient<IApiMatchService, ApiMatchService>(client => client.BaseAddress = new Uri("https://localhost:44336/api/matches/")) ;

            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
