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
    ///     Controller de TipoSecao.
    /// </summary>
    [Produces("application/json")]
    [Route("tiposecao")]
    [AllowAnonymous]
    public class TipoSecaoController : BaseController<TipoSecaoViewModel, TipoSecaoFilter, TipoSecao>
    {
        private new readonly ITipoSecaoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TipoSecaoController"/> class.
        ///     Contrutor padrão do TipoSecaoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public TipoSecaoController(
            ITipoSecaoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<TipoSecaoController>();
        }
    }
}
