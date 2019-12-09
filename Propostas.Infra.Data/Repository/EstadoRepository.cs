namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IEstadoRepository"/>.
    /// </summary>
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoRepository"/> class.
        ///     Construtor padrão de <see cref="EstadoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public EstadoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
