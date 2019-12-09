namespace Propostas.WebApi
{
    using global::AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Propostas.Infra.CrossCutting.IoC;
    using Propostas.Infra.Data.Seeds;
    using Propostas.WebApi.Configurations;
    using Swashbuckle.AspNetCore.Swagger;
    using System.IO;
    using System.Net;

    /// <summary>
    ///     A classe de inicialização do projeto. Seta todas as configurações do projeto.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     O appConfig do projeto. Todas as configurações foram carregadas aqui.
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        ///     O contrutor padrão. Carrega o arquivo de configuração (appConfig.js).
        /// </summary>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            //if (env.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Startup>();
            //}

            builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        /// <summary>
        ///     Configurando todos os serviços do projeto.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("PropostasConnection")));

            #region Seeds

            // Não remova ou edite a linha abaixo. Utilizado para gerar código automático
            // AddNewSeedInitializer //
            services.AddTransient<TagInitializer>();
            services.AddTransient<SecaoArquivoTagInitializer>();
            services.AddTransient<PropostaTagInitializer>();
            services.AddTransient<UsuarioInitializer>();
            services.AddTransient<PropostaInitializer>();
            services.AddTransient<TemplateSecaoInitializer>();
            services.AddTransient<TemplateInitializer>();
            services.AddTransient<SecaoInitializer>();
            services.AddTransient<StatusPropostaInitializer>();
            services.AddTransient<TiposContatoInitializer>();
            services.AddTransient<PerfilUsuarioInitializer>();
            services.AddTransient<ContatoInitializer>();
            services.AddTransient<RecursoInitializer>();
            services.AddTransient<TipoSecaoInitializer>();
            services.AddTransient<LinguagemInitializer>();
            services.AddTransient<TipoTemplateInitializer>();
            services.AddTransient<PublicoAlvoInitializer>();
            services.AddTransient<MoedaInitializer>();
            services.AddTransient<ClienteInitializer>();
            services.AddTransient<ProdutoInitializer>();
            services.AddTransient<UnidadeMedidaInitializer>();
            services.AddTransient<PaisInitializer>();
            services.AddTransient<EstadoInitializer>();
            services.AddTransient<CidadeInitializer>();

            services.AddTransient<SeedInitializer>();

            #endregion Seeds
            
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            });

            // ============================
            // Register Automapper
            // ============================
            services.AddAutoMapper();
            services.AddMediatR(typeof(Startup));

            // ============================
            // Register the Swagger generator, defining one or more Swagger documents
            // ============================
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info { Version = "v1", Title = "Propostas", Description = "Propostas API Swagger Surface", Contact = new Contact { Name = "Blend IT" } });
            });
            
            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            SeedInitializer seeder,
            IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            await context.Response.WriteAsync("<h2>An error has occured in the website.</h2>").ConfigureAwait(false);
                        }
                    });
                });
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseMvc();

            seeder.Seed();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Propostas Project API v1.0");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
