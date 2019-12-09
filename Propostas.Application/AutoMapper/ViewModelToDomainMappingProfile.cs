namespace Propostas.Application.AutoMapper
{
    using global::AutoMapper;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // Não remova ou edite a linha abaixo. Utilizado para gerar código automático
            // AddNewConf //
            this.CreateMap<TagViewModel, Tag>();

            this.CreateMap<SecaoArquivoTagViewModel, SecaoArquivoTag>();

            this.CreateMap<PropostaTagViewModel, PropostaTag>();

            this.CreateMap<UsuarioViewModel, Usuario>();

            this.CreateMap<PropostaViewModel, Proposta>();

            this.CreateMap<TemplateSecaoViewModel, TemplateSecao>();

            this.CreateMap<TemplateViewModel, Template>()
                .AfterMap((src, dest) =>
                {
                    dest.TemplateSecoes = new List<TemplateSecao>();
                    if (src.Secoes != null && src.Secoes.Any())
                    {
                        foreach (var secaoId in src.Secoes)
                        {
                            if (secaoId.HasValue)
                            {
                                dest.TemplateSecoes.Add(new TemplateSecao
                                {
                                    SecaoId = secaoId.Value,
                                    TemplateId = src.Id
                                });
                            }
                        }
                    }
                });

            this.CreateMap<SecaoViewModel, Secao>()
                .ForMember(dest => dest.SecaoArquivo, opt => opt.Ignore());

            //this.CreateMap<SecaoArquivoViewModel, SecaoArquivo>()
            //.ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.ToTitleCase()))
            //.ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => Guid.NewGuid()))
            //.ForMember(dest => dest.Publicado, opt => opt.MapFrom(src => DateTime.Now))
            //.AfterMap((src, dest) =>
            //{
            //    dest.Url = "https://testeblendit.blob.core.windows.net/dev-propostas/arquivoSessao/" + dest.Codigo;
            //});

            this.CreateMap<StatusPropostaViewModel, StatusProposta>();


            this.CreateMap<SecaoArquivoViewModel, SecaoArquivo>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.UrlArquivo.ToLowerCase()));

            this.CreateMap<TiposContatoViewModel, TiposContato>();

            this.CreateMap<PerfilUsuarioViewModel, PerfilUsuario>();

            this.CreateMap<ContatoViewModel, Contato>();

            this.CreateMap<RecursoViewModel, Recurso>();

            this.CreateMap<TipoSecaoViewModel, TipoSecao>();

            this.CreateMap<LinguagemViewModel, Linguagem>();

            this.CreateMap<TipoTemplateViewModel, TipoTemplate>();

            this.CreateMap<PublicoAlvoViewModel, PublicoAlvo>();

            this.CreateMap<MoedaViewModel, Moeda>();

            this.CreateMap<ClienteViewModel, Cliente>();

            this.CreateMap<ProdutoViewModel, Produto>();

            this.CreateMap<UnidadeMedidaViewModel, UnidadeMedida>();

            this.CreateMap<CidadeViewModel, Cidade>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.ToTitleCase()));

            this.CreateMap<EstadoViewModel, Estado>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.ToTitleCase()))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Uf.ToUpperCase()));

            this.CreateMap<PaisViewModel, Pais>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.ToTitleCase()))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo.ToTitleCase()));
        }
    }
}
