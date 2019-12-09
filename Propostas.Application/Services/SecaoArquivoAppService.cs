namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Enumerators;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.CrossCutting.Core.Messages;
    using Propostas.Infra.CrossCutting.Utils.Extensions;
    using Propostas.Infra.CrossCutting.Utils.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///     Implementação da <see cref="ISecaoArquivoAppService"/>.
    /// </summary>
    public class SecaoArquivoAppService : BaseAppService<SecaoArquivoViewModel, SecaoArquivoFilter, SecaoArquivo>, ISecaoArquivoAppService
    {
        private readonly ITagAppService tagService;
        private readonly ISecaoArquivoTagAppService secaoArquivoTagService;
        private readonly IAzureBlobService azureBlobService;
        private readonly IDocumentService documentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecaoArquivoAppService"/> class.
        ///     Construtor padrão de <see cref="SecaoArquivoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Recurso. Veja <see cref="ISecaoArquivoRepository"/>.
        /// </param>
        public SecaoArquivoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ISecaoArquivoRepository repository,
            ITagAppService tagService,
            ISecaoArquivoTagAppService secaoArquivoTagService,
            IAzureBlobService azureBlobService,
            IDocumentService documentService)
            : base(uow, mapper, repository)
        {
            this.tagService = tagService;
            this.secaoArquivoTagService = secaoArquivoTagService;
            this.azureBlobService = azureBlobService;
            this.documentService = documentService;
        }

        /// <summary>
        ///     Salva o registro passado como parâmetro.
        /// </summary>
        public override SecaoArquivoViewModel Add(SecaoArquivoViewModel model, bool commit = true)
        {
            #region Validações

            var extensaoArquivo = model.Nome.RegexReplace(@"^(.*\.)", string.Empty);
            if (extensaoArquivo != "docx")
            {
                throw new PropostasException("Permitido apenas arquivos no formato docx.");
            }

            #endregion Validações

            var arquivoAzurePath = "https://testeblendit.blob.core.windows.net/dev-propostas/arquivosessao/" + Guid.NewGuid().ToString() + ".docx";
            model.UrlArquivo = arquivoAzurePath;
            model.Versao = 1;

            #region Controle de Versão

            var ultimoArquivoAtivo = this.repository.GetBy(arquivo => arquivo.SecaoId == model.SecaoId && arquivo.Ativo == true).LastOrDefault();
            // Se havia um arquivo ativo anteriormente, devemos deixá-lo desativado e incrementar a versao do novo
            if (ultimoArquivoAtivo != null)
            {
                ultimoArquivoAtivo.Ativo = false;
                this.repository.Update(ultimoArquivoAtivo);

                model.Versao = (ultimoArquivoAtivo.Versao ?? 0) + 1;
            }

            #endregion Controle de Versão

            var entity = this.mapper.Map<SecaoArquivo>(model);

            // Realizando o upload do arquivo solicitado
            var bytes = Convert.FromBase64String(model.Base64Arquivo.Split(',')[1]);
            this.azureBlobService.Upload(bytes, arquivoAzurePath);

            var localPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".docx";

            //var resultados = new List<SecaoArquivo>();
            //var secaoArquivo = new SecaoArquivo()
            //{
            //    Nome = nomeArquivo,
            //    Publicado = DateTime.Now,
            //    Url = arquivoAzurePath,
            //    Versao = 1,
            //    SecaoArquivoTags = new List<SecaoArquivoTag>()
            //};

            try
            {
                //grava os bytes do arquivo em localPath
                File.WriteAllBytes(localPath, bytes);

                //   this.azureBlobService.Download(localPath, arquivoAzurePath, true);

                // Controle das tags
                var tags = this.documentService.GetTags(localPath);

                foreach (var tag in tags)
                {
                    var tagSplit = tag.Split(':');
                    var tagTipo = TagTipoEnum.Texto;
                    var tagChave = string.Empty;
                    if (tagSplit.Length == 2)
                    {
                        var tagTipoString = tagSplit[0];
                        switch (tagTipoString)
                        {
                            case "texto":
                                tagTipo = TagTipoEnum.Texto;
                                break;

                            case "imagem":
                                tagTipo = TagTipoEnum.Imagem;
                                break;

                            default:
                                tagTipo = TagTipoEnum.Texto;
                                break;
                        }

                        tagChave = tagSplit[1];
                    }

                    // verifica se a tag já existe no bd
                    var tagDb = this.tagService.GetBy(t => t.Chave == tagChave && t.Tipo == tagTipo.GetDescription()).FirstOrDefault();
                    // Salva tag que ainda não existe no banco
                    if (tagDb == null)
                    {
                        var tagViewModel = new TagViewModel()
                        {
                            Tipo = tagTipo.GetDescription(),
                            Chave = tagChave
                        };

                        // Incluindo uma nova tag
                        tagDb = this.tagService.Add(tagViewModel, false);
                    }
                    //verifica se SeçãoArquivoTag não existe

                    var secaoArquivoTag = new SecaoArquivoTag()
                    {
                        TagId = tagDb.Id,
                        SecaoArquivoId = entity.Id
                    };

                    entity.SecaoArquivoTags.Add(secaoArquivoTag);
                }
            }
            finally
            {
                File.Delete(localPath);
            }



            this.repository.Add(entity);

            this.Commit(commit);

            model.Id = entity.Id;

            return model;
        }

        /// <summary>
        ///     Obtém os registros utilizando a expressão utilizada no parâmetro.
        /// </summary>
        public override IEnumerable<SecaoArquivoViewModel> GetBy(Expression<Func<SecaoArquivo, bool>> expression)
        {
            var results = this.repository.GetBy(expression)
                                         .OrderByDescending(sa => sa.Versao)
                                         .ThenByDescending(sa => sa.Id)
                                         .ToList();

            return this.mapper.Map<IEnumerable<SecaoArquivoViewModel>>(results);
        }

        public void RemovePorSecao(int secaoId, bool commit = false)
        {
            var arquivos = this.repository.GetBy(secaoArquivo => secaoArquivo.SecaoId == secaoId).ToList();

            foreach (var arquivo in arquivos)
             {
                this.azureBlobService.Remove(arquivo.Url);
                this.repository.Remove(arquivo.Id);
            }

            this.Commit(commit);
        }

        /// <summary>
        /// Altera o status do registro
        /// </summary>
        public override void ModificaStatus(int id, bool commit = true)
        {
            var entity = this.repository.GetById(id);
            if (entity == null)
            {
                throw new PropostasException(Messages.NotFound);
            }
            //Busca os arquivos que estão ativos
            var arquivosAtivos = this.repository.GetBy(secaoArquivo => secaoArquivo.SecaoId == entity.SecaoId && secaoArquivo.Id != entity.Id).ToList();

            //Desativa os arquivos buscados
            foreach (var arquivoAtivo in arquivosAtivos)
            {
                arquivoAtivo.Ativo = false;
                this.repository.Update(arquivoAtivo);

            }
            entity.Ativo = true;
            this.repository.Update(entity);
            this.Commit(commit);
        }

        private IEnumerable<string> GetTags(string filePath)
        {
            var tags = new List<string>();



            return tags;
        }

    }
}

