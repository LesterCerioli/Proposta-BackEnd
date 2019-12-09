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
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///     Implementação da <see cref="IPropostaAppService"/>.
    /// </summary>
    public class PropostaAppService : BaseAppService<PropostaViewModel, PropostaFilter, Proposta>, IPropostaAppService
    {
        private readonly ITemplateSecaoRepository templateSecaoRepository;
        private readonly IRecursoRepository recursoRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IAzureBlobService azureBlobService;
        private readonly IDocumentService documentService;
        private readonly ISecaoArquivoTagRepository secaoArquivoTagRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropostaAppService"/> class.
        ///     Construtor padrão de <see cref="PropostaAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Proposta. Veja <see cref="IPropostaRepository"/>.
        /// </param>
        public PropostaAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IPropostaRepository repository,
            ITemplateSecaoRepository templateSecaoRepository,
            IRecursoRepository recursoRepository,
            IClienteRepository clienteRepository,
            IAzureBlobService azureBlobService,
            IDocumentService documentService,
            ISecaoArquivoTagRepository secaoArquivoTagRepository)
            : base(uow, mapper, repository)
        {
            this.templateSecaoRepository = templateSecaoRepository;
            this.recursoRepository = recursoRepository;
            this.clienteRepository = clienteRepository;
            this.azureBlobService = azureBlobService;
            this.documentService = documentService;
            this.secaoArquivoTagRepository = secaoArquivoTagRepository;
        }

        /// <summary>
        ///     Obtém os registros utilizando o filtro utilizado no parâmetro.
        /// </summary>
        public override ResponseViewModel GetBy(PropostaFilter filter, params Expression<Func<Proposta, object>>[] includes)
        {
            #region Filters 

            var expression = PredicateBuilder.True<Proposta>();

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

            Func<Proposta, object> orderBy;
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
                Data = this.mapper.Map<IEnumerable<PropostaViewModel>>(results),
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
        ///     Obtém o registro cujo ID é o passado como parâmetro.
        /// </summary>
        public override PropostaViewModel GetById(int id)
        {
            var result = this.repository.GetBy(c => c.Id == id, "PropostaTags.SecaoArquivoTag.Tag").FirstOrDefault();
            var propostaview = this.mapper.Map<PropostaViewModel>(result);
            return propostaview;
        }

        /// <summary>
        ///     Obtém os registros do histórico utilizando o filtro utilizado no parâmetro.
        /// </summary>
        public ResponseViewModel GetByHist(PropostaFilter filter, params Expression<Func<Proposta, object>>[] includes)
        {
            #region Filters 

            var expression = PredicateBuilder.True<Proposta>();

            if (filter == null || !filter.Codigo.HasValue)
            {
                throw new PropostasException("Código da proposta não informado.");
            }

            expression = expression.And(f => f.Codigo == filter.Codigo.Value);

            #endregion Filters 

            #region OrderBy

            Func<Proposta, object> orderBy;
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
                Data = this.mapper.Map<IEnumerable<PropostaViewModel>>(results),
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
        ///     Salva o registro passado como parâmetro.
        /// </summary>
        public override PropostaViewModel Add(PropostaViewModel model, bool commit = true)
        {
            var entity = this.mapper.Map<Proposta>(model);
            entity.PropostaTags = new List<PropostaTag>();


            foreach (var propostaTag in model.PropostaTags)
            {
                var tag = this.secaoArquivoTagRepository.GetBy(sa => sa.Tag.Chave == propostaTag.Chave && sa.Tag.Tipo == propostaTag.Tipo).FirstOrDefault();

                if (tag != null)
                {
                    var obj = new PropostaTag();
                    obj.SecaoArquivoTagId = tag.Id;
                    obj.Valor = propostaTag.Valor;
                    obj.Base64 = propostaTag.Base64;
                    entity.PropostaTags.Add(obj);
                }
            }

            entity.Cliente = this.clienteRepository.GetById(entity.ClienteId);
            entity.Codigo = Guid.NewGuid();
            entity.Versao = 1;


            model.Id = this.Add(entity, commit);

            return model;
        }

        public override void Update(PropostaViewModel model, bool commit = true)
        {
            #region Validações

            if (model.Id == 0)
            {
                throw new PropostasException(Messages.NotFound);
            }

            var propostaDb = this.repository.GetById(model.Id);
            if (propostaDb == null)
            {
                throw new PropostasException(Messages.NotFound);
            }

            #endregion Validações

            // Desativando a última proposta para gerar uma nova versão
            propostaDb.Ativo = false;
            this.repository.Update(propostaDb);

            var entity = this.mapper.Map<Proposta>(model);
            entity.PropostaTags = new List<PropostaTag>();

            foreach (var propostaTag in model.PropostaTags)
            {
                var tag = this.secaoArquivoTagRepository.GetBy(sa => sa.Tag.Chave == propostaTag.Chave && sa.Tag.Tipo == propostaTag.Tipo).FirstOrDefault();

                if (tag != null)
                {
                    var obj = new PropostaTag();
                    obj.SecaoArquivoTagId = tag.Id;
                    obj.Valor = propostaTag.Valor;
                    obj.Base64 = propostaTag.Base64;
                    entity.PropostaTags.Add(obj);
                }
            }


            entity.Id = 0;
            entity.Cliente = this.clienteRepository.GetById(entity.ClienteId);
            entity.Codigo = propostaDb.Codigo;
            entity.Versao = propostaDb.Versao + 1;

            this.Add(entity, commit);
        }

        private int Add(Proposta proposta, bool commit = true)
        {
            var docsUrlsAzure = this.templateSecaoRepository
                .GetBy(c => c.TemplateId == proposta.TemplateId, c => c.Secao.SecaoArquivo)
                .Select(sc => sc.Secao.SecaoArquivo.Where(sa => sa.Ativo).Select(sa => sa.Url).First())
                .ToList();

            if (docsUrlsAzure != null)
            {
                // Realizando todos os downloads do Azure
                var docsUrlLocal = this.azureBlobService.Download(docsUrlsAzure, false);

                try
                {
                    // Realizando replace das tags nos documentos que serão realizados merge
                    this.ReplaceTags(docsUrlLocal, proposta);

                    // Realizando merge dos documentos baixados anteriormente
                    var destinationLocalPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".docx";
                    this.documentService.MergeFromLocal(docsUrlLocal, destinationLocalPath);

                    // Salvando o arquivo resultante do merge no Azure;
                    var azureDocxPath = "https://testeblendit.blob.core.windows.net/dev-propostas/arquivoSessao/" + Guid.NewGuid() + ".docx";
                    this.azureBlobService.Upload(destinationLocalPath, azureDocxPath);

                    var localPdfPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
                    var azurePdfPath = "https://testeblendit.blob.core.windows.net/dev-propostas/arquivoSessao/" + Guid.NewGuid() + ".pdf";

                    this.documentService.ConvertDocxToPdf(destinationLocalPath, localPdfPath);
                    this.azureBlobService.Upload(localPdfPath, azurePdfPath);

                    proposta.UrlArquivo = azurePdfPath;
                   // proposta.UrlPdf = azurePdfPath;
                }
                finally
                {
                    // Deletando os arquivos locais guardados em docsUrlLocal
                    foreach (var docUrlLocal in docsUrlLocal)
                    {
                        if (File.Exists(docUrlLocal))
                        {
                            File.Delete(docUrlLocal);
                        }
                    }
                }
            }

            this.repository.Add(proposta);
            this.Commit(commit);

            return proposta.Id;
        }

        private void ReplaceTags(ICollection<string> filePaths, Proposta proposta)
        {
            var dictionary = new Dictionary<string, string>();


            foreach (var tag in proposta.PropostaTags)
            {
                var secaoArquivoTag = this.secaoArquivoTagRepository.GetBy(sa => sa.Id == tag.SecaoArquivoTagId, sa => sa.Tag).FirstOrDefault();
                if (secaoArquivoTag != null)
                {
                    var tipo = secaoArquivoTag.Tag.Tipo;
                    var chave = "{{" + tipo + ":" + secaoArquivoTag.Tag.Chave + "}}";
                    dictionary.Add(chave, string.IsNullOrEmpty(tag.Base64) ? tag.Valor : tag.Base64);
                }
            }


            foreach (var filePath in filePaths)
            {
                this.documentService.ReplaceTags(filePath, dictionary);
            }
        }

        /// <summary>
        ///     Remove o registro que possui o identificador passado no parâmetro.
        /// </summary>
        public override void Remove(int id, bool commit = true)
        {
            var entity = this.repository.GetById(id);

            var propostasVersion = this.repository.GetBy(p => p.Codigo == entity.Codigo).ToList();

            foreach (var item in propostasVersion)
            {
                this.azureBlobService.Remove(item.UrlArquivo);
                //this.azureBlobService.Remove(item.UrlPdf);
                this.repository.Remove(item.Id);
            }
            this.Commit(commit);
        }
    }
}
