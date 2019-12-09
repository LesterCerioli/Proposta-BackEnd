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
    ///     Controller de StatusProposta.
    /// </summary>
    [Produces("application/json")]
    [Route("statusproposta")]
    [AllowAnonymous]
    public class StatusPropostaController : BaseController<StatusPropostaViewModel, StatusPropostaFilter, StatusProposta>
    {
        private new readonly IStatusPropostaAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusPropostaController"/> class.
        ///     Contrutor padrão do StatusPropostaController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public StatusPropostaController(
            IStatusPropostaAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<StatusPropostaController>();
        }
    }
}
