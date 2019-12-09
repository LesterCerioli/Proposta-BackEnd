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
    ///     Controller de Moeda.
    /// </summary>
    [Produces("application/json")]
    [Route("moeda")]
    [AllowAnonymous]
    public class MoedaController : BaseController<MoedaViewModel, MoedaFilter, Moeda>
    {
        private new readonly IMoedaAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoedaController"/> class.
        ///     Contrutor padrão do MoedaController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public MoedaController(
            IMoedaAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<MoedaController>();
        }
    }
}
