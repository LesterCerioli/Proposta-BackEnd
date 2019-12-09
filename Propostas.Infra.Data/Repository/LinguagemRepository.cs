namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ILinguagemRepository"/>.
    /// </summary>
    public class LinguagemRepository : BaseRepository<Linguagem>, ILinguagemRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LinguagemRepository"/> class.
        ///     Construtor padrão de <see cref="LinguagemRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public LinguagemRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
