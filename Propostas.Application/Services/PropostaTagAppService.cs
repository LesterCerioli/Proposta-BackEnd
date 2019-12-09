namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IPropostaTagAppService"/>.
    /// </summary>
    public class PropostaTagAppService : BaseAppService<PropostaTagViewModel, PropostaTagFilter, PropostaTag>, IPropostaTagAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropostaTagAppService"/> class.
        ///     Construtor padrão de <see cref="PropostaTagAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade PropostaTag. Veja <see cref="IPropostaTagRepository"/>.
        /// </param>

        public PropostaTagAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IPropostaTagRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
