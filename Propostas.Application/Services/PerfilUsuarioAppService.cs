namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IPerfilUsuarioAppService"/>.
    /// </summary>
    public class PerfilUsuarioAppService : BaseAppService<PerfilUsuarioViewModel, PerfilUsuarioFilter, PerfilUsuario>, IPerfilUsuarioAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PerfilUsuarioAppService"/> class.
        ///     Construtor padrão de <see cref="PerfilUsuarioAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade PerfilUsuario. Veja <see cref="IPerfilUsuarioRepository"/>.
        /// </param>

        public PerfilUsuarioAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IPerfilUsuarioRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
