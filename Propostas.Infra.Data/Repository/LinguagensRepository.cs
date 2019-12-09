namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ILinguagensRepository"/>.
    /// </summary>
    public class LinguagensRepository : BaseRepository<Linguagens>, ILinguagensRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LinguagensRepository"/> class.
        ///     Construtor padrão de <see cref="LinguagensRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public LinguagensRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
