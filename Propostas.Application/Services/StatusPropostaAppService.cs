namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IStatusPropostaAppService"/>.
    /// </summary>
    public class StatusPropostaAppService : BaseAppService<StatusPropostaViewModel, StatusPropostaFilter, StatusProposta>, IStatusPropostaAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusPropostaAppService"/> class.
        ///     Construtor padrão de <see cref="StatusPropostaAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade StatusProposta. Veja <see cref="IStatusPropostaRepository"/>.
        /// </param>

        public StatusPropostaAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IStatusPropostaRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
