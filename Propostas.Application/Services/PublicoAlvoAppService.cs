namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IPublicoAlvoAppService"/>.
    /// </summary>
    public class PublicoAlvoAppService : BaseAppService<PublicoAlvoViewModel, PublicoAlvoFilter, PublicoAlvo>, IPublicoAlvoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicoAlvoAppService"/> class.
        ///     Construtor padrão de <see cref="PublicoAlvoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade PublicoAlvo. Veja <see cref="IPublicoAlvoRepository"/>.
        /// </param>

        public PublicoAlvoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IPublicoAlvoRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
