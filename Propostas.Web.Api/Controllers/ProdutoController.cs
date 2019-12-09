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
    ///     Controller de Produto.
    /// </summary>
    [Produces("application/json")]
    [Route("produto")]
    [AllowAnonymous]
    public class ProdutoController : BaseController<ProdutoViewModel, ProdutoFilter, Produto>
    {
        private new readonly IProdutoAppService appService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProdutoController"/> class.
        ///     Contrutor padrão do ProdutoController.
        /// </summary>
        /// <param name="appService">Application de serviço</param>
        /// <param name="loggerFactory">Factory de gerenciamento de logs</param>
        public ProdutoController(
            IProdutoAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<ProdutoController>();
        }
    }
}
