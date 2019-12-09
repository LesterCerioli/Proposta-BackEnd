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
    ///     Controller de País.
    /// </summary>
    [Produces("application/json")]
    [Route("pais")]
    [AllowAnonymous]
    public class PaisController : BaseController<PaisViewModel, PaisFilter, Pais>
    {
        private readonly IPaisAppService paisAppService;
        private readonly IEstadoAppService estadoAppService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaisController"/> class.
        ///     Contrutor padrão do PaísController.
        /// </summary>
        /// <param name="paisAppService">Application de serviço de País</param>
        /// <param name="estadoAppService">Application de serviço de Estado</param>
        /// <param name="notifications">Notifications Handler</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public PaisController(
            IPaisAppService paisAppService,
            IEstadoAppService estadoAppService,
            ILoggerFactory loggerFactory)
            : base(paisAppService)
        {
            this.paisAppService = paisAppService;
            this.estadoAppService = estadoAppService;
            this.logger = loggerFactory.CreateLogger<PaisController>();
        }

        /// <summary>
        ///     Obtém todos os Estados do país informado.
        /// </summary>
        /// <param name="id">
        ///     Identificador do País.
        /// </param>
        [HttpGet]
        [Route("{id:int}/estado")]
        public IActionResult GetEstados(int id)
        {
            var result = this.estadoAppService.GetByPais(id);
            return this.Response(result);
        }
    }
}
