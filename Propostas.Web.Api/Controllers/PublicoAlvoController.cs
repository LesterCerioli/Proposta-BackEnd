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
    ///     Controller de PublicoAlvo.
    /// </summary>
    [Produces("application/json")]
    [Route("publicoalvo")]
    [AllowAnonymous]
    public class PublicoAlvoController : BaseController<PublicoAlvoViewModel, PublicoAlvoFilter, PublicoAlvo>
    {
        private new readonly IPublicoAlvoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicoAlvoController"/> class.
        ///     Contrutor padrão do PublicoAlvoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public PublicoAlvoController(
            IPublicoAlvoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<PublicoAlvoController>();
        }
    }
}
