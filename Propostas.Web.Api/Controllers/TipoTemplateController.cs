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
    ///     Controller de TipoTemplate.
    /// </summary>
    [Produces("application/json")]
    [Route("tipotemplate")]
    [AllowAnonymous]
    public class TipoTemplateController : BaseController<TipoTemplateViewModel, TipoTemplateFilter, TipoTemplate>
    {
        private new readonly ITipoTemplateAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TipoTemplateController"/> class.
        ///     Contrutor padrão do TipoTemplateController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public TipoTemplateController(
            ITipoTemplateAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<TipoTemplateController>();
        }
    }
}
