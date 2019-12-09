namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="ITipoTemplateAppService"/>.
    /// </summary>
    public class TipoTemplateAppService : BaseAppService<TipoTemplateViewModel, TipoTemplateFilter, TipoTemplate>, ITipoTemplateAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TipoTemplateAppService"/> class.
        ///     Construtor padrão de <see cref="TipoTemplateAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade TipoTemplate. Veja <see cref="ITipoTemplateRepository"/>.
        /// </param>

        public TipoTemplateAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ITipoTemplateRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
