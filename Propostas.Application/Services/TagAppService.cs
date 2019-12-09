namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="ITagAppService"/>.
    /// </summary>
    public class TagAppService : BaseAppService<TagViewModel, TagFilter, Tag>, ITagAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagAppService"/> class.
        ///     Construtor padrão de <see cref="TagAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Tag. Veja <see cref="ITagRepository"/>.
        /// </param>

        public TagAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ITagRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
