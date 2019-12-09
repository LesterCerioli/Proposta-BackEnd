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
    ///     Controller de TiposContato.
    /// </summary>
    [Produces("application/json")]
    [Route("tiposcontato")]
    [AllowAnonymous]
    public class TiposContatoController : BaseController<TiposContatoViewModel, TiposContatoFilter, TiposContato>
    {
        private new readonly ITiposContatoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TiposContatoController"/> class.
        ///     Contrutor padrão do TiposContatoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public TiposContatoController(
            ITiposContatoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<TiposContatoController>();
        }

        
    }
}
