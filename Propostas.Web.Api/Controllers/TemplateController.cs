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
    ///     Controller de Template.
    /// </summary>
    [Produces("application/json")]
    [Route("template")]
    [AllowAnonymous]
    public class TemplateController : BaseController<TemplateViewModel, TemplateFilter, Template>
    {
        private new readonly ITemplateAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateController"/> class.
        ///     Contrutor padrão do TemplateController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public TemplateController(
            ITemplateAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<TemplateController>();
        }
       


        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        [HttpGet("historico")]
        public IActionResult GetByHist(TemplateFilter filter)
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
        [HttpGet("{id}/tag")]
        public IActionResult GetByTags(int id)
        {
            try
            {
                var results = this.appService.GetByTags(id);
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
