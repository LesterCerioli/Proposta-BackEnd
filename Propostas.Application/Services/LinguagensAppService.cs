namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="ILinguagensAppService"/>.
    /// </summary>
    public class LinguagensAppService : BaseAppService<LinguagensViewModel, LinguagensFilter, Linguagens>, ILinguagensAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinguagensAppService"/> class.
        ///     Construtor padrão de <see cref="LinguagensAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Linguagens. Veja <see cref="ILinguagensRepository"/>.
        /// </param>

        public LinguagensAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ILinguagensRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
