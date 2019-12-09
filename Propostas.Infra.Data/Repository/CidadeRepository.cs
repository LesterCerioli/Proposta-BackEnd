namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ICidadeRepository"/>.
    /// </summary>
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CidadeRepository"/> class.
        ///     Construtor padrão de <see cref="CidadeRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public CidadeRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
