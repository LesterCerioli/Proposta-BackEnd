namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.Pagers;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Enumerators;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.CrossCutting.Core.Messages;
    using Propostas.Infra.CrossCutting.Utils.Builders;
    using Propostas.Infra.CrossCutting.Utils.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///     Implementação da <see cref="ITemplateAppService"/>.
    /// </summary>
    public class TemplateAppService : BaseAppService<TemplateViewModel, TemplateFilter, Template>, ITemplateAppService
    {
        private readonly ISecaoAppService secaoService;
        private readonly ITemplateSecaoAppService templateSecaoService;
        private readonly ITemplateSecaoRepository templateSecaoRepository;
        private readonly IPropostaRepository propostaRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateAppService"/> class.
        ///     Construtor padrão de <see cref="TemplateAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Template. Veja <see cref="ITemplateRepository"/>.
        /// </param>
        public TemplateAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ITemplateRepository repository,
            ISecaoAppService secaoService,
            ITemplateSecaoAppService templateSecaoService,
            ITemplateSecaoRepository templateSecaoRepository,
            IPropostaRepository propostaRepository)
            : base(uow, mapper, repository)
        {
            this.secaoService = secaoService;
            this.templateSecaoService = templateSecaoService;
            this.templateSecaoRepository = templateSecaoRepository;
            this.propostaRepository = propostaRepository;
        }

        /// <summary>
        ///     Obtém o registro cujo ID é o passado como parâmetro.
        /// </summary>
        /// 

        public override TemplateViewModel GetById(int id)
        {
            var result = this.repository.GetBy(c => c.Id == id, c => c.TemplateSecoes).FirstOrDefault();
            return this.mapper.Map<TemplateViewModel>(result);
        }

        /// <summary>
        ///     Salva o registro passado como parâmetro.
        /// </summary>
        /// 
        public override TemplateViewModel Add(TemplateViewModel model, bool commit = true)
        {
            var entity = this.mapper.Map<Template>(model);
            //adiciona valor a versao e Codigo
            entity.Versao = 1;
            entity.Codigo = Guid.NewGuid();

            this.repository.Add(entity);

            this.Commit(commit);

            model.Id = entity.Id;

            return model;
        }
        /// <summary>
        ///     Atualiza o registro passado como parâmetro.
        /// </summary>
        public override void Update(TemplateViewModel model, bool commit = true)
        {
            if (model.Id == 0)
            {
                throw new PropostasException(Messages.NotFound);
            }
            var entity = this.mapper.Map<Template>(model);


            var templateAnterior = this.repository.GetById(model.Id);

            templateAnterior.Ativo = false;
            var codigo = templateAnterior.Codigo;
            var versao = templateAnterior.Versao + 1;

            entity.Id = 0;
            entity.Versao = versao;
            entity.Codigo = codigo;

            this.repository.Add(entity);

            this.repository.Update(templateAnterior);

            this.Commit(commit);

        }

        /// <summary>
        ///     Remove o registro que possui o identificador passado no parâmetro.
        /// </summary>
        public override void Remove(int id, bool commit = true)
        {

            var entity = this.repository.GetById(id);

            var templateVersion = this.repository.GetBy(p => p.Codigo == entity.Codigo).ToList();
            var proposta = this.propostaRepository.GetBy(p => p.TemplateId == entity.Id).FirstOrDefault();

            if (proposta != null)
            {
                throw new PropostasException("Não é possível excluir este template.");
            }
            else
            {
                foreach (var template in templateVersion)
                {
                    var secoes = this.repository.GetBy(t => t.Id == template.Id, t => t.TemplateSecoes).FirstOrDefault();

                    foreach (var templateSecao in template.TemplateSecoes)
                    {
                        this.templateSecaoService.Remove(templateSecao.Id, false);
                    }
                    this.repository.Remove(id);
                }
            }
            this.Commit(commit);
        }

        /// <summary>
        ///     Obtém os registros utilizando a expressão utilizada no parâmetro.
        /// </summary>
        public IEnumerable<TemplateViewModel> GetByTemplate(int id, bool commit = true)
        {
            var getTemplate = this.repository.GetBy(template => template.Id == id).FirstOrDefault();

            var results = this.repository.GetBy(templates => templates.Codigo == getTemplate.Codigo && templates.Id != getTemplate.Id);

            return this.mapper.Map<IEnumerable<TemplateViewModel>>(results);
        }

        /// <summary>
        ///     Obtém os registros utilizando a expressão utilizada no parâmetro.
        /// </summary>
        public IEnumerable<TagViewModel> GetByTags(int id)
        {
            var results = this.repository.GetBy(templates => templates.Id == id, "TemplateSecoes.Secao.SecaoArquivo.SecaoArquivoTags.Tag").ToList();
            var tags = new List<TagViewModel>();
            foreach (var item in results)
            {
                foreach (var templateSecao in item.TemplateSecoes)
                {
                    var secaoArquivo = templateSecao.Secao.SecaoArquivo.Where(sa => sa.Ativo).FirstOrDefault();
                    if (secaoArquivo != null)
                    {
                        foreach (var secaoTag in secaoArquivo.SecaoArquivoTags)
                        {
                            // Lista apenas tags "não especiais" - especial = 0
                            if (secaoTag.Tag.Especial == false)
                            {
                                var tagExists = tags.Where(x => x.Id == secaoTag.TagId).FirstOrDefault();
                                if (tagExists == null)
                                {
                                    var tag = secaoTag.Tag;
                                    tags.Add(this.mapper.Map<TagViewModel>(tag));
                                }
                            }
                        }
                    }
                }
            }
            return tags;
        }

        /// <summary>
        ///     Obtém os registros utilizando o filtro utilizado no parâmetro.
        /// </summary>
        public override ResponseViewModel GetBy(TemplateFilter filter, params Expression<Func<Template, object>>[] includes)
        {
            #region Filters 

            var expression = PredicateBuilder.True<Template>();

            if (filter != null)
            {
                if (filter.Id.HasValue)
                {
                    expression = expression.And(f => f.Id == filter.Id.Value);
                }

                if (filter.Ativo.HasValue)
                {
                    expression = expression.And(f => f.Ativo == filter.Ativo.Value);
                }
            }

            #endregion Filters 

            #region OrderBy

            Func<Template, object> orderBy;
            filter.SortBy = filter.SortBy ?? string.Empty;
            switch (filter.SortBy.ToLower())
            {
                case "ativo":
                    orderBy = (x => x.Ativo);
                    break;
                default:
                    orderBy = (x => x.Id);
                    break;
            }

            var orderByDirection = OrderByDirectionEnum.Ascending;
            if (filter.SortDirection.ToLowerCase() == "desc")
            {
                orderByDirection = OrderByDirectionEnum.Descending;
            }


            #endregion OrderBy

            #region Pager

            var pager = new Pager()
            {
                PageNumber = filter.PageNumber ?? 0,
                PageSize = filter.PageSize ?? 25,
                HasPagination = filter.HasPagination
            };

            #endregion Pager

            var query = this.repository.GetBy(expression);

            if (filter.LastVersion.HasValue && filter.LastVersion.Value == true)
            {
                query = query.Where(x => x.Versao == this.repository.GetAll().Where(y => y.Codigo == x.Codigo).Select(y => y.Versao).Max());
            }

            var results = this.repository.GetByPaged(query, orderBy, orderByDirection, pager).ToList();

            var totalItems = query.Count();
            var totalPages = 1;
            if (filter.HasPagination)
            {
                if (filter.PageSize.HasValue)
                {
                    var ceilingResult = Math.Ceiling((decimal)totalItems / (decimal)filter.PageSize.Value);
                    totalPages = int.Parse(ceilingResult.ToString());
                }
            }

            var response = new ResponseViewModel
            {
                Data = this.mapper.Map<IEnumerable<TemplateViewModel>>(results),
                Page = new PageViewModel
                {
                    PageNumber = filter.HasPagination ? (filter.PageNumber ?? 1) : 1,
                    Size = filter.HasPagination ? (filter.PageSize ?? totalItems) : totalItems,
                    TotalElements = totalItems,
                    TotalPages = totalPages
                },
                Success = true
            };

            return response;
        }

        /// <summary>
        ///     Obtém os registros do histórico utilizando o filtro utilizado no parâmetro.
        /// </summary>
        public ResponseViewModel GetByHist(TemplateFilter filter, params Expression<Func<Template, object>>[] includes)
        {
            #region Filters 

            var expression = PredicateBuilder.True<Template>();

            if (filter == null || !filter.Codigo.HasValue)
            {
                throw new PropostasException("Código do template não informado.");
            }

            expression = expression.And(f => f.Codigo == filter.Codigo.Value);

            #endregion Filters 

            #region OrderBy

            Func<Template, object> orderBy;
            filter.SortBy = filter.SortBy ?? string.Empty;
            switch (filter.SortBy.ToLower())
            {
                case "ativo":
                    orderBy = (x => x.Ativo);
                    break;
                default:
                    orderBy = (x => x.Id);
                    break;
            }

            var orderByDirection = OrderByDirectionEnum.Ascending;
            if (filter.SortDirection.ToLowerCase() == "desc")
            {
                orderByDirection = OrderByDirectionEnum.Descending;
            }

            #endregion OrderBy

            #region Pager

            var pager = new Pager()
            {
                PageNumber = filter.PageNumber ?? 0,
                PageSize = filter.PageSize ?? 25,
                HasPagination = filter.HasPagination
            };

            #endregion Pager

            var query = this.repository.GetBy(expression, includes);
            var results = this.repository.GetByPaged(query, orderBy, orderByDirection, pager).ToList();

            var totalItems = this.repository.Count(expression);
            var totalPages = 1;
            if (filter.HasPagination)
            {
                if (filter.PageSize.HasValue)
                {
                    var ceilingResult = Math.Ceiling((decimal)totalItems / (decimal)filter.PageSize.Value);
                    totalPages = int.Parse(ceilingResult.ToString());
                }
            }

            var response = new ResponseViewModel
            {
                Data = this.mapper.Map<IEnumerable<TemplateViewModel>>(results),
                Page = new PageViewModel
                {
                    PageNumber = filter.HasPagination ? (filter.PageNumber ?? 1) : 1,
                    Size = filter.HasPagination ? (filter.PageSize ?? totalItems) : totalItems,
                    TotalElements = totalItems,
                    TotalPages = totalPages
                },
                Success = true
            };

            return response;
        }
    }
}
