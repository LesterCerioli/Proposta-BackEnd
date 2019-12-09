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
    ///     Controller de Recurso.
    /// </summary>
    [Produces("application/json")]
    [Route("recurso")]
    [AllowAnonymous]
    public class RecursoController : BaseController<RecursoViewModel, RecursoFilter, Recurso>
    {
        private new readonly IRecursoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecursoController"/> class.
        ///     Contrutor padrão do RecursoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public RecursoController(
            IRecursoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<RecursoController>();
        }
    }
}
