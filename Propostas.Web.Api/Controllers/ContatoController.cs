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
    ///     Controller de Contato.
    /// </summary>
    [AllowAnonymous]
    public class ContatoController : BaseController<ContatoViewModel, ContatoFilter, Contato>
    {
        private new readonly IContatoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContatoController"/> class.
        ///     Contrutor padrão do ContatoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>

        public ContatoController(
            IContatoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<ContatoController>();
        }

        [HttpGet("cliente/{id}")]
        public IActionResult GetByCliente(int id)
        {
            try
            {
                var item = this.appService.GetBy(contato => contato.ClienteId == id);
                return this.Response(item);
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
