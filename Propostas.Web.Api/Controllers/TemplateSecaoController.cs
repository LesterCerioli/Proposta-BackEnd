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
    ///     Controller de TemplateSecao.
    /// </summary>
    [Produces("application/json")]
    [Route("templatesecao")]
    [AllowAnonymous]
    public class TemplateSecaoController : BaseController<TemplateSecaoViewModel, TemplateSecaoFilter, TemplateSecao>
    {
        private new readonly ITemplateSecaoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateSecaoController"/> class.
        ///     Contrutor padrão do TemplateSecaoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public TemplateSecaoController(
            ITemplateSecaoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<TemplateSecaoController>();
        }
    }
}
