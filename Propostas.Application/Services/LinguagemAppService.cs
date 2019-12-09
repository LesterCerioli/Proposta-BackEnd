namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="ILinguagemAppService"/>.
    /// </summary>
    public class LinguagemAppService : BaseAppService<LinguagemViewModel, LinguagemFilter, Linguagem>, ILinguagemAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinguagemAppService"/> class.
        ///     Construtor padrão de <see cref="LinguagemAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Linguagem. Veja <see cref="ILinguagemRepository"/>.
        /// </param>

        public LinguagemAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ILinguagemRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
