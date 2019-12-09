namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="IProdutoAppService"/>.
    /// </summary>
    public class ProdutoAppService : BaseAppService<ProdutoViewModel, ProdutoFilter, Produto>, IProdutoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProdutoAppService"/> class.
        ///     Construtor padrão de <see cref="ProdutoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Produto. Veja <see cref="IProdutoRepository"/>.
        /// </param>

        public ProdutoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IProdutoRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
