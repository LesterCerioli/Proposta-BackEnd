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
    ///     Controller de PropostaTag.
    /// </summary>
    [Produces("application/json")]
    [Route("propostatag")]
    [AllowAnonymous]
    public class PropostaTagController : BaseController<PropostaTagViewModel, PropostaTagFilter, PropostaTag>
    {
        private new readonly IPropostaTagAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropostaTagController"/> class.
        ///     Contrutor padrão do PropostaTagController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public PropostaTagController(
            IPropostaTagAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<PropostaTagController>();
        }
    }
}
