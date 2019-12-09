namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.File;
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
    using System.Web;

    /// <summary>
    ///     Implementação da <see cref="ISecaoAppService"/>.
    /// </summary>
    public class SecaoAppService : BaseAppService<SecaoViewModel, SecaoFilter, Secao>, ISecaoAppService
    {

        private readonly ITagAppService tagService;
        private readonly IAzureBlobService azureBlobService;
        private readonly ISecaoArquivoAppService secaoArquivoService;
        private readonly ISecaoArquivoRepository secaoArquivoRepository;
        private readonly ITemplateSecaoRepository templateSecaoRepository;

        private readonly IDocumentService documentService;


        /// <summary>
        /// Initializes a new instance of the <see cref="SecaoAppService"/> class.
        ///     Construtor padrão de <see cref="SecaoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Secao. Veja <see cref="ISecaoRepository"/>.
        /// </param>
        public SecaoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ISecaoRepository repository,
            IAzureBlobService azureBlobService,
            ISecaoArquivoAppService secaoArquivoAppService,
            ISecaoArquivoRepository secaoArquivoRepository,
            ITemplateSecaoRepository templateSecaoRepository,
            IDocumentService documentService,
            ITagAppService tagService)
            : base(uow, mapper, repository)
        {
            this.tagService = tagService;
            this.templateSecaoRepository = templateSecaoRepository;
            this.secaoArquivoService = secaoArquivoAppService;
            this.secaoArquivoRepository = secaoArquivoRepository;
            this.azureBlobService = azureBlobService;
            this.documentService = documentService;
        }

        public override SecaoViewModel Add(SecaoViewModel model, bool commit = true)
        {
            var entity = this.mapper.Map<Secao>(model);

            var extensaoArquivo = model.SecaoArquivo.Nome.RegexReplace(@"^(.*\.)", string.Empty);
            if (extensaoArquivo != "docx")
            {
                throw new PropostasException("Permitido apenas arquivos no formato docx.");
            }

            var arquivoAzurePath = "https://testeblendit.blob.core.windows.net/dev-propostas/arquivoSessao/" + Guid.NewGuid().ToString() + ".docx";
            entity.SecaoArquivo = new List<SecaoArquivo>()
            {
                new SecaoArquivo()
                {
                    Nome = model.SecaoArquivo.Nome,
                    Publicado = DateTime.Now,
                    Url = arquivoAzurePath,
                    Versao = 1,
                    SecaoArquivoTags = new List<SecaoArquivoTag>()
                }
            };
            // 1) Para cada tag encontrada no documento:
            //  1.1) Salva tag se nao existir
            //  1.2) Obtem o ID da tag;
            //  1.3) Cria um SecaoArquivoTag contendo a referencia de TagId
            //  1.4) Inclui o SecaoArquivoTag criado em 3 na lista entity.SecaoArquivo.First().SecaoArquivoTags.Add();
            // 2) Salva objeto em this.repository.Add(entity);
            // Salvando no Azure
            var bytes = Convert.FromBase64String(model.SecaoArquivo.Base64Arquivo.Split(',')[1]);
            //encontrar as tags do arquivo

            var localPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".docx";

            //this.secaoArquivoService.Add(model.SecaoArquivo, false);
            this.azureBlobService.Upload(bytes, arquivoAzurePath);
         

            try
            {
                //grava os bytes do arquivo em localPath
                File.WriteAllBytes(localPath, bytes);
                
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
                    
                    var secaoArquivoTag = new SecaoArquivoTag()
                    {
                        TagId = tagDb.Id
                    };

                    entity.SecaoArquivo.First().SecaoArquivoTags.Add(secaoArquivoTag);



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
        ///     Atualiza o registro passado como parâmetro.
        /// </summary>
        public override void Update(SecaoViewModel model, bool commit = true)
        {
            if (model.Id == 0)
            {
                throw new PropostasException(Messages.NotFound);
            }

            var entity = this.mapper.Map<Secao>(model);

            if (model.SecaoArquivo.Base64Arquivo != null)
            {
                model.SecaoArquivo.SecaoId = entity.Id;
                this.secaoArquivoService.Add(model.SecaoArquivo, false);
            }

            this.repository.Update(entity);

            this.Commit(commit);
        }

        public override void Remove(int id, bool commit = true)
        {
            var entity = this.repository.GetById(id);
            //dados dos Arquivos da Secao
            var verifyTemplate = this.templateSecaoRepository.GetBy(ts => ts.SecaoId == entity.Id).FirstOrDefault();

            if (verifyTemplate != null)
            {
                throw new PropostasException("Não é possível excluir esta seção.");
            }

            this.secaoArquivoService.RemovePorSecao(entity.Id);
            this.repository.Remove(id);
            this.Commit(commit);
        }
    }
}
