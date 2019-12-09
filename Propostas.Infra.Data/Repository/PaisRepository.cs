namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IPaisRepository"/>.
    /// </summary>
    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaisRepository"/> class.
        ///     Construtor padrão de <see cref="PaisRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public PaisRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
