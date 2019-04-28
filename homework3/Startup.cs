using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModulSchool.BusinessLogic;
using ModulSchool.Services;
using ModulSchool.Services.Interfaces;
using MassTransit;
using homework3.Commands;
using homework3.Consumers;
using Microsoft.Extensions.Hosting;

namespace homework3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddScoped<GetUsersInfoRequestHandler>();
            //services.AddScoped<IUserInfoService, UserInfoService>();
            // Обработчики событий MassTransit
            services.AddScoped<AppendUserConsumer>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<AppendUserConsumer>();
                x.AddBus(provider => MassTransit.Bus.Factory.CreateUsingInMemory(cfg =>
                {
                    cfg.ReceiveEndpoint("append-user-queue", ep =>
                    {
                        ep.ConfigureConsumer<AppendUserConsumer>(provider);
                        EndpointConvention.Map<AppendUserCommand>(ep.InputAddress);
                    });
                }));

                x.AddRequestClient<AppendUserCommand>();
            });

            services.AddSingleton<IHostedService, BusService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
