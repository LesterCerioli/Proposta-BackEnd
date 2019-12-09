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
    ///     Controller de Usuario.
    /// </summary>
    [Produces("application/json")]
    [Route("usuario")]
    [AllowAnonymous]
    public class UsuarioController : BaseController<UsuarioViewModel, UsuarioFilter, Usuario>
    {
        private new readonly IUsuarioAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioController"/> class.
        ///     Contrutor padrão do UsuarioController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public UsuarioController(
            IUsuarioAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<UsuarioController>();
        }
    }
}
