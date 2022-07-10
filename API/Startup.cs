using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.SyncDataServices.Http;
using Application.AsyncDataService;
using Application.Core;
using Application.Data;
using Application.EventProcessing;
using Application.Queries.Lectures;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API
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

            services.AddControllers();

            services.AddHostedService<MessageBusSubscriber>();

            services.AddDbContext<LectureGroupContext>(opt =>
            {
                //opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                // opt.LogTo(Console.WriteLine);
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddHttpClient<IUsersDataClient, HttpUsersDataClient>();

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddMediatR(typeof(GetAllLectures.Handler).Assembly);

            services.AddSingleton<IMessageBusClient, MessageBusClient>();

            services.AddSingleton<IEventProcessor, EventProcessor>();

            services.AddScoped<ILectureGroupRepo, LectureGroupRepo>();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials().WithOrigins("http://localhost:3000");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
