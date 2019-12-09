namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IPaisAppService"/>.
    /// </summary>
    public class PaisAppService : BaseAppService<PaisViewModel, PaisFilter, Pais>, IPaisAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaisAppService"/> class.
        ///     Construtor padrão de <see cref="PaisAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="bus">
        ///     Barramento de comandos. Veja <see cref="IMediatorHandler"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Pais. Veja <see cref="IPaisRepository"/>.
        /// </param>

        public PaisAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IPaisRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
