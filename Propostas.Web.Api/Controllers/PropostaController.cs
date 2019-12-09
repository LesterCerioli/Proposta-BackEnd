namespace Propostas.WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using System;

    /// <summary>
    ///     Controller de Proposta.
    /// </summary>
    [Produces("application/json")]
    [Route("proposta")]
    [AllowAnonymous]
    public class PropostaController : BaseController<PropostaViewModel, PropostaFilter, Proposta>
    {
        private new readonly IPropostaAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropostaController"/> class.
        ///     Contrutor padrão do PropostaController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public PropostaController(
            IPropostaAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<PropostaController>();
        }

        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        [HttpGet("historico")]
        public IActionResult GetByHist(PropostaFilter filter)
        {
            try
            {
                var results = this.appService.GetByHist(filter);
                return this.Response(results);
            }
            catch (PropostasException emx)
            {
                return this.Response(emx);
            }
            catch (Exception ex)
            {
                return this.Response(ex);
            }
        }
    }
}
