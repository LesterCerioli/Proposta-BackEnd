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
    ///     Controller de Cidade.
    /// </summary>
    [AllowAnonymous]
    public class CidadeController : BaseController<CidadeViewModel, CidadeFilter, Cidade>
    {
        private readonly ICidadeAppService cidadeAppService;
        private readonly ILogger logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CidadeController"/> class.
        ///     Contrutor padrão da CidadeController.
        /// </summary>
        /// <param name="cidadeAppService">Application de serviço de Cidade</param>
        /// <param name="notifications">Notifications Handler</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public CidadeController(
            ICidadeAppService cidadeAppService,
            ILoggerFactory loggerFactory)
            : base(cidadeAppService)
        {
            this.cidadeAppService = cidadeAppService;
            this.logger = loggerFactory.CreateLogger<CidadeController>();
        }

        /// <summary>
        ///     Obtém uma cidade cujo código IBGE é o passado como parâmetro.
        /// </summary>
        /// <param name="codigo">
        ///     Código da cidade conforme a tabela do IBGE.
        /// </param>
        [HttpGet]
        [Route("{codigo}")]
        public IActionResult GetByCodigoIbge(string codigo)
        {
            try
            {
                var result = this.cidadeAppService.GetByCodigoIbge(codigo);
                return this.Response(result);
            }
            catch (PropostasException mex)
            {
                // Exceção já está tratada.
                // Insira mais tratamentos caso houver a necessidade.
                this.logger.LogInformation(mex.Message);
            }
            catch (Exception ex)
            {
                // Loga a mensagem de erro no log
                // var logMessage = ex.ToLogMessage(out this.ErrorCode);
                // this.logger.LogCritical(logMessage);

                return this.Response(ex);
            }

            return this.Response();
        }
    }
}
