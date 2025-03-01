﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessor.Processor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ImageProcessor
{
    public class Startup
    {
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(o => o.InputFormatters.Insert(0, new RawRequestBodyFormatter()));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "CPSC 5200 Image Processor ",
                    Description = "Example of API Usage - 'http://localhost:5000/image?operations=rotateleft,resize(10),rotateright,thumbnail,grayscale(0)'",
                    Version = "v1",
                    Contact = new Contact()
                    {
                        Name = "Sonali",
                        Email = "dsouzasonali@outlook.com"
                    }
                });
            });

        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CPSC 5200 Image Processor");
            });

            app.UseMvc();
        }
    }
}
