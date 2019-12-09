namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IUnidadeMedidaAppService"/>.
    /// </summary>
    public class UnidadeMedidaAppService : BaseAppService<UnidadeMedidaViewModel, UnidadeMedidaFilter, UnidadeMedida>, IUnidadeMedidaAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnidadeMedidaAppService"/> class.
        ///     Construtor padrão de <see cref="UnidadeMedidaAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade UnidadeMedida. Veja <see cref="IUnidadeMedidaRepository"/>.
        /// </param>

        public UnidadeMedidaAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IUnidadeMedidaRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
