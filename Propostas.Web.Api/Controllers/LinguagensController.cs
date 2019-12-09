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
    ///     Controller de Linguagens.
    /// </summary>
    [Produces("application/json")]
    [Route("linguagens")]
    [AllowAnonymous]
    public class LinguagensController : BaseController<LinguagensViewModel, LinguagensFilter, Linguagens>
    {
        private new readonly ILinguagensAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinguagensController"/> class.
        ///     Contrutor padrão do LinguagensController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public LinguagensController(
            ILinguagensAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<LinguagensController>();
        }
    }
}
