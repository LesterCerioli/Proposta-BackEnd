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
    ///     Controller de Estado.
    /// </summary>
    [AllowAnonymous]
    public class EstadoController : BaseController<EstadoViewModel, EstadoFilter, Estado>
    {
        private readonly IEstadoAppService estadoAppService;
        private readonly ICidadeAppService cidadeAppService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoController"/> class.
        ///     Contrutor padrão do EstadoController.
        /// </summary>
        /// <param name="estadoAppService">Application de serviço de Estado</param>
        /// <param name="cidadeAppService">Application de serviço de Cidade</param>
        /// <param name="notifications">Notifications Handler</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public EstadoController(
            IEstadoAppService estadoAppService,
            ICidadeAppService cidadeAppService,
            ILoggerFactory loggerFactory)
            : base(estadoAppService)
        {
            this.estadoAppService = estadoAppService;
            this.cidadeAppService = cidadeAppService;
            this.logger = loggerFactory.CreateLogger<EstadoController>();
        }

        /// <summary>
        ///     Obtém todas as cidades do estado informado.
        /// </summary>
        /// <param name="id">
        ///     Identificador do estado.
        /// </param>
        [HttpGet]
        [Route("{id:int}/cidade")]
        public IActionResult GetCidades(int id)
        {
            var result = this.cidadeAppService.GetByEstado(id);
            return this.Response(result);
        }
    }
}
