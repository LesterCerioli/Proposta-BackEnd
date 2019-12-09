namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="ITiposContatoAppService"/>.
    /// </summary>
    public class TiposContatoAppService : BaseAppService<TiposContatoViewModel, TiposContatoFilter, TiposContato>, ITiposContatoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TiposContatoAppService"/> class.
        ///     Construtor padrão de <see cref="TiposContatoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade TiposContato. Veja <see cref="ITiposContatoRepository"/>.
        /// </param>

        public TiposContatoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ITiposContatoRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
