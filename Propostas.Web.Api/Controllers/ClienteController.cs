namespace Propostas.WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.Logging;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Controller de Cliente.
    /// </summary>
    [AllowAnonymous]
    public class ClienteController : BaseController<ClienteViewModel, ClienteFilter, Cliente>
    {
        private new readonly IClienteAppService appService;
        private readonly ILogger logger;

        public ClienteController(
            IClienteAppService appService,
            ILoggerFactory loggerFactory)
            : base(appService)
        {
            this.appService = appService;
            this.logger = loggerFactory.CreateLogger<ClienteController>();
        }
    }
}
