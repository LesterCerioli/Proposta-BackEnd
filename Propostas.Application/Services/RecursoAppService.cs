namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IRecursoAppService"/>.
    /// </summary>
    public class RecursoAppService : BaseAppService<RecursoViewModel, RecursoFilter, Recurso>, IRecursoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecursoAppService"/> class.
        ///     Construtor padrão de <see cref="RecursoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Recurso. Veja <see cref="IRecursoRepository"/>.
        /// </param>

        public RecursoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IRecursoRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
