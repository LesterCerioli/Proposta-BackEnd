namespace Propostas.WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Controller de SecaoArquivoTag.
    /// </summary>
    [Produces("application/json")]
    [Route("secaoarquivotag")]
    [AllowAnonymous]
    public class SecaoArquivoTagController : BaseController<SecaoArquivoTagViewModel, SecaoArquivoTagFilter, SecaoArquivoTag>
    {
        private new readonly ISecaoArquivoTagAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecaoArquivoTagController"/> class.
        ///     Contrutor padrão do SecaoArquivoTagController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public SecaoArquivoTagController(
            ISecaoArquivoTagAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<SecaoArquivoTagController>();
        }
    }
}
