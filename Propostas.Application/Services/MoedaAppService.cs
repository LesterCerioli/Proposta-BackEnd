namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IMoedaAppService"/>.
    /// </summary>
    public class MoedaAppService : BaseAppService<MoedaViewModel, MoedaFilter, Moeda>, IMoedaAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoedaAppService"/> class.
        ///     Construtor padrão de <see cref="MoedaAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Moeda. Veja <see cref="IMoedaRepository"/>.
        /// </param>

        public MoedaAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IMoedaRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
