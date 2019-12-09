namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IRecursoRepository"/>.
    /// </summary>
    public class RecursoRepository : BaseRepository<Recurso>, IRecursoRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RecursoRepository"/> class.
        ///     Construtor padrão de <see cref="RecursoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public RecursoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
