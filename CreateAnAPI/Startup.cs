using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreateAnAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreateAnAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures Services used by API
        /// </summary>
        /// <param name="services">Services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:ProductionDB"]);
            });
            services.AddMvc().AddXmlDataContractSerializerFormatters();
        }

        /// <summary>
        /// Configures HTTP request pipeline
        /// </summary>
        /// <param name="app">Applications used by program</param>
        /// <param name="env">Environmental Variables</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
