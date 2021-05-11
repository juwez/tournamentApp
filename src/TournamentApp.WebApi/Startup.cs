using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Code;
using TournamentApp.Services.Dtos.Tournament;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.WebApi
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
            var connectionString = Configuration.GetConnectionString("FirebaseDatabaseUrl");
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<ITournamentRepository>(x => 
                new TournamentRepository(connectionString));
            services.AddTransient<ITournamentService, TournamentService>();
            
            services.AddTransient<IRoundRepository>(x => 
                new RoundRepository(connectionString));
            services.AddTransient<IRoundService, RoundService>();
            
            
            services.AddTransient<ITournamentRoundRepository>(x => 
                new TournamentRoundRepository(connectionString));
            services.AddTransient<ITournamentRoundService, TournamentRoundService>();
            
            services.AddTransient<IRoundMatchService, RoundMatchService>();

            services.AddTransient<IPlayerRepository>(x => 
                new PlayerRepository(connectionString));
            services.AddTransient<IPlayerService, PlayerService>();
            
            services.AddTransient<IMatchRepository>(x => 
                new MatchRepository(connectionString));
            services.AddTransient<IMatchService, MatchService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //todo delete these lines
            Console.WriteLine(env.IsProduction());
            Console.WriteLine(env.IsDevelopment());
            Console.WriteLine(env.IsStaging());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}