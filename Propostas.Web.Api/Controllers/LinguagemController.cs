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
    ///     Controller de Linguagem.
    /// </summary>
    [Produces("application/json")]
    [Route("linguagem")]
    [AllowAnonymous]
    public class LinguagemController : BaseController<LinguagemViewModel, LinguagemFilter, Linguagem>
    {
        private new readonly ILinguagemAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinguagemController"/> class.
        ///     Contrutor padrão do LinguagemController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public LinguagemController(
            ILinguagemAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<LinguagemController>();
        }
    }
}
