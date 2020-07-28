using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FinalProjectCodenation.Data;
using FinalProjectCodenation.Interfaces;
using FinalProjectCodenation.V2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FinalProjectCodenation
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
            services.AddDbContext<LogErrorContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            //    services.AddSingleton<IRepository, Repository>();

            //    services.AddTransient<IRepository, Repository>();


            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            var apiProviderDescription = services.BuildServiceProvider()
                                                .GetService<IApiVersionDescriptionProvider>();

            services.AddControllers()
            .AddNewtonsoftJson(
                opt => opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //procura nas dll quem herda de profile

            services.AddSwaggerDocumentation();

            foreach (var description in apiProviderDescription.ApiVersionDescriptions)
            {



                services.AddSwaggerGen(option =>
                {
                    option.SwaggerDoc(
                        description.GroupName,
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Log Error Final Project API",
                            Version = description.ApiVersion.ToString(),
                            TermsOfService = new Uri("http://MeusTermosdeUso.com"),
                            Description = "API para criar endpoints para serem usados pelo SWAGGER da aplica��o criar um endpoint que ser� usado para gravar os logs de erro em um banco de dados relacional a API deve ser seguros permitindo acesso apenas com um token de autentica��o v�lidohool",
                            License = new Microsoft.OpenApi.Models.OpenApiLicense
                            {
                                Name = "Log Error Final Project Licence",
                                Url = new Uri("https://www.linkedin.com/in/engwillianxavier/")
                            },
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact
                            {
                                Name = "Willian Daniel Menezes Xavier",
                                Email = "engeletwill@gmail.com",
                                Url = new Uri("https://www.linkedin.com/in/engwillianxavier/")
                            }

                        }
                    );
                    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                    option.IncludeXmlComments(xmlCommentsFullPath);
                    
                });

            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                 IWebHostEnvironment env,
                                 IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant()
                        );
                    }

                    options.RoutePrefix = "";
                });

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


/*
 * 
 * "ConnectionStrings": {
    "Default": "Data Source=SmartSchool.db"
  },
*/