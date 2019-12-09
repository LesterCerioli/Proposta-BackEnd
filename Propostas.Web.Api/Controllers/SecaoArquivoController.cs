namespace Propostas.WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using Propostas.Infra.CrossCutting.Core.Messages;
    using System;
    using System.Net;

    /// <summary>
    ///     Controller de Secao.
    /// </summary>
    [Produces("application/json")]
    [Route("secaoarquivo")]
    [AllowAnonymous]
    public class SecaoArquivoController : BaseController<SecaoArquivoViewModel, SecaoArquivoFilter, SecaoArquivo>
    {
        private new readonly ISecaoArquivoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecaoArquivoController"/> class.
        ///     Contrutor padrão do SecaoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public SecaoArquivoController(
            ISecaoArquivoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<SecaoArquivoController>();
        }

        [HttpGet("secao/{id}")]
        public IActionResult GetBySecao(int id)
        {
            try
            {
                var item = this.appService.GetBy(secaoArquivo => secaoArquivo.SecaoId == id);
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
