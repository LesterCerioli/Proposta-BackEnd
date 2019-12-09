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
    ///     Implementação da <see cref="IContatoAppService"/>.
    /// </summary>
    public class ContatoAppService : BaseAppService<ContatoViewModel, ContatoFilter, Contato>, IContatoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContatoAppService"/> class.
        ///     Construtor padrão de <see cref="ContatoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Contato. Veja <see cref="IContatoRepository"/>.
        /// </param>

        public ContatoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IContatoRepository repository)
            : base(uow, mapper, repository)
        {
        }

    }
}
