namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IUsuarioAppService"/>.
    /// </summary>
    public class UsuarioAppService : BaseAppService<UsuarioViewModel, UsuarioFilter, Usuario>, IUsuarioAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioAppService"/> class.
        ///     Construtor padrão de <see cref="UsuarioAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Usuario. Veja <see cref="IUsuarioRepository"/>.
        /// </param>

        public UsuarioAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IUsuarioRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
