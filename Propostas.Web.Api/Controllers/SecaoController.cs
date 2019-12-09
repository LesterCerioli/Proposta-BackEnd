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
    ///     Controller de Secao.
    /// </summary>
    [Produces("application/json")]
    [Route("secao")]
    [AllowAnonymous]
    public class SecaoController : BaseController<SecaoViewModel, SecaoFilter, Secao>
    {
        private new readonly ISecaoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecaoController"/> class.
        ///     Contrutor padrão do SecaoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public SecaoController(
            ISecaoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<SecaoController>();
        }
    }
}
