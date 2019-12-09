namespace Propostas.Infra.CrossCutting.IoC
{
    using global::AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Propostas.Application.AutoMapper;
    using Propostas.Application.Interfaces;
    using Propostas.Application.Services;
    using Propostas.Domain.Interfaces;
    using Propostas.Infra.CrossCutting.Utils.Interfaces;
    using Propostas.Infra.CrossCutting.Utils.Services;
    using Propostas.Infra.Data.Context;
    using Propostas.Infra.Data.Repository;
    using Propostas.Infra.Data.UoW;

    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            // services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            #region Application

            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());

            // Não remova ou edite a linha abaixo. Utilizado para gerar código automático
            // AddAppService //
            services.AddScoped<ITagAppService, TagAppService>();
            services.AddScoped<ISecaoArquivoTagAppService, SecaoArquivoTagAppService>();
            services.AddScoped<IPropostaTagAppService, PropostaTagAppService>();
            // services.AddScoped<IAzureBlobAppService, AzureBlobAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IPropostaAppService, PropostaAppService>();
            services.AddScoped<ITemplateSecaoAppService, TemplateSecaoAppService>();
            services.AddScoped<ITemplateAppService, TemplateAppService>();
            services.AddScoped<ISecaoAppService, SecaoAppService>();

            services.AddScoped<ISecaoArquivoAppService, SecaoArquivoAppService>();
            services.AddScoped<IStatusPropostaAppService, StatusPropostaAppService>();
            services.AddScoped<ITiposContatoAppService, TiposContatoAppService>();
            services.AddScoped<IPerfilUsuarioAppService, PerfilUsuarioAppService>();
            services.AddScoped<IContatoAppService, ContatoAppService>();
            services.AddScoped<IRecursoAppService, RecursoAppService>();
            services.AddScoped<ITipoSecaoAppService, TipoSecaoAppService>();
            services.AddScoped<ILinguagemAppService, LinguagemAppService>();
            services.AddScoped<ITipoTemplateAppService, TipoTemplateAppService>();
            services.AddScoped<IPublicoAlvoAppService, PublicoAlvoAppService>();
            services.AddScoped<IMoedaAppService, MoedaAppService>();
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IUnidadeMedidaAppService, UnidadeMedidaAppService>();
            services.AddScoped<IPaisAppService, PaisAppService>();
            services.AddScoped<IEstadoAppService, EstadoAppService>();
            services.AddScoped<ICidadeAppService, CidadeAppService>();

            #endregion Application

            #region Infra - Data

            // Não remova ou edite a linha abaixo. Utilizado para gerar código automático
            // AddNewRepository //
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ISecaoArquivoTagRepository, SecaoArquivoTagRepository>();
            services.AddScoped<IPropostaTagRepository, PropostaTagRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPropostaRepository, PropostaRepository>();
            services.AddScoped<ITemplateSecaoRepository, TemplateSecaoRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<ISecaoRepository, SecaoRepository>();
            services.AddScoped<ISecaoArquivoRepository, SecaoArquivoRepository>();
            services.AddScoped<IStatusPropostaRepository, StatusPropostaRepository>();
            services.AddScoped<ITiposContatoRepository, TiposContatoRepository>();
            services.AddScoped<IPerfilUsuarioRepository, PerfilUsuarioRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IRecursoRepository, RecursoRepository>();
            services.AddScoped<ITipoSecaoRepository, TipoSecaoRepository>();
            services.AddScoped<ILinguagemRepository, LinguagemRepository>();
            services.AddScoped<ITipoTemplateRepository, TipoTemplateRepository>();
            services.AddScoped<IPublicoAlvoRepository, PublicoAlvoRepository>();
            services.AddScoped<IMoedaRepository, MoedaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PropostasContext>();

            #endregion Infra - Data

            services.AddSingleton<IAzureBlobService, AzureBlobService>();
            services.AddSingleton<IDocumentService, DocumentService>();
        }
    }
}
