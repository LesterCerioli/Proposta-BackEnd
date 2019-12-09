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
    ///     Controller de PerfilUsuario.
    /// </summary>
    [Produces("application/json")]
    [Route("perfilusuario")]
    [AllowAnonymous]
    public class PerfilUsuarioController : BaseController<PerfilUsuarioViewModel, PerfilUsuarioFilter, PerfilUsuario>
    {
        private new readonly IPerfilUsuarioAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerfilUsuarioController"/> class.
        ///     Contrutor padrão do PerfilUsuarioController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public PerfilUsuarioController(
            IPerfilUsuarioAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<PerfilUsuarioController>();
        }
    }
}
