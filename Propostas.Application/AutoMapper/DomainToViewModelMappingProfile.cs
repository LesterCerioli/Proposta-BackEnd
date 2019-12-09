namespace Propostas.Application.AutoMapper
{
    using global::AutoMapper;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            // Não remova ou edite a linha abaixo. Utilizado para gerar código automático
            // AddNewConf //
            this.CreateMap<Tag, TagViewModel>().MaxDepth(1);

            this.CreateMap<SecaoArquivoTag, SecaoArquivoTagViewModel>().MaxDepth(1);

            this.CreateMap<PropostaTag, PropostaTagViewModel>().MaxDepth(1)
                .ForMember(dest => dest.Chave, opt => opt.MapFrom(src => (src.SecaoArquivoTag != null && src.SecaoArquivoTag.Tag != null) ? src.SecaoArquivoTag.Tag.Chave : string.Empty))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (src.SecaoArquivoTag != null && src.SecaoArquivoTag.Tag != null) ? src.SecaoArquivoTag.Tag.Tipo : string.Empty));

            this.CreateMap<Usuario, UsuarioViewModel>().MaxDepth(1);

            this.CreateMap<Proposta, PropostaViewModel>().MaxDepth(1);

            this.CreateMap<TemplateSecao, TemplateSecaoViewModel>().MaxDepth(1);

            this.CreateMap<Template, TemplateViewModel>().MaxDepth(1)
                .AfterMap((src, dest) => {
                    dest.Secoes = new List<int?>();

                    if (src.TemplateSecoes != null && src.TemplateSecoes.Any())
                    {
                        foreach(var templateSecao in src.TemplateSecoes)
                        {
                            dest.Secoes.Add(templateSecao.SecaoId);
                        }
                    }
                });

            this.CreateMap<Secao, SecaoViewModel>().MaxDepth(1);

            this.CreateMap<SecaoArquivo, SecaoArquivoViewModel>().MaxDepth(1)
                .ForMember(dest => dest.UrlArquivo, opt => opt.MapFrom(src => src.Url));

            this.CreateMap<StatusProposta, StatusPropostaViewModel>().MaxDepth(1);

            this.CreateMap<TiposContato, TiposContatoViewModel>().MaxDepth(1);

            this.CreateMap<PerfilUsuario, PerfilUsuarioViewModel>().MaxDepth(1);

            this.CreateMap<Contato, ContatoViewModel>().MaxDepth(1);

            this.CreateMap<Recurso, RecursoViewModel>().MaxDepth(1);

            this.CreateMap<TipoSecao, TipoSecaoViewModel>().MaxDepth(1);

            this.CreateMap<Linguagem, LinguagemViewModel>().MaxDepth(1);

            this.CreateMap<TipoTemplate, TipoTemplateViewModel>().MaxDepth(1);

            this.CreateMap<PublicoAlvo, PublicoAlvoViewModel>().MaxDepth(1);

            this.CreateMap<Moeda, MoedaViewModel>().MaxDepth(1);

            this.CreateMap<Cliente, ClienteViewModel>().MaxDepth(1);

            this.CreateMap<Produto, ProdutoViewModel>().MaxDepth(1);
            this.CreateMap<UnidadeMedida, UnidadeMedidaViewModel>().MaxDepth(1);
            this.CreateMap<Pais, PaisViewModel>().MaxDepth(1);
            this.CreateMap<Estado, EstadoViewModel>().MaxDepth(1);
            this.CreateMap<Cidade, CidadeViewModel>().MaxDepth(1);
        }
    }
}
