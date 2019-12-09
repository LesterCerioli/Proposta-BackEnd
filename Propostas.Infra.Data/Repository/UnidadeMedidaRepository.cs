namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IUnidadeMedidaRepository"/>.
    /// </summary>
    public class UnidadeMedidaRepository : BaseRepository<UnidadeMedida>, IUnidadeMedidaRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnidadeMedidaRepository"/> class.
        ///     Construtor padrão de <see cref="UnidadeMedidaRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public UnidadeMedidaRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
