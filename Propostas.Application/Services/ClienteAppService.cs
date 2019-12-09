namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using System;

    /// <summary>
    ///     Implementação da <see cref="IClienteAppService"/>.
    /// </summary>
    public class ClienteAppService : BaseAppService<ClienteViewModel, ClienteFilter, Cliente>, IClienteAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClienteAppService"/> class.
        ///     Construtor padrão de <see cref="ClienteAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Cliente. Veja <see cref="IClienteRepository"/>.
        /// </param>

        public ClienteAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IClienteRepository repository)
            : base(uow, mapper, repository)
        {
        }
       

    }
}
