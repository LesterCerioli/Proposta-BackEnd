namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IProdutoRepository"/>.
    /// </summary>
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProdutoRepository"/> class.
        ///     Construtor padrão de <see cref="ProdutoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public ProdutoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
