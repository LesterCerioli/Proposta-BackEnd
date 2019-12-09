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
    ///     Controller de UnidadeMedida.
    /// </summary>
    [Produces("application/json")]
    [Route("unidademedida")]
    [AllowAnonymous]
    public class UnidadeMedidaController : BaseController<UnidadeMedidaViewModel, UnidadeMedidaFilter, UnidadeMedida>
    {
        private new readonly IUnidadeMedidaAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnidadeMedidaController"/> class.
        ///     Contrutor padrão do UnidadeMedidaController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public UnidadeMedidaController(
            IUnidadeMedidaAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<UnidadeMedidaController>();
        }
    }
}
