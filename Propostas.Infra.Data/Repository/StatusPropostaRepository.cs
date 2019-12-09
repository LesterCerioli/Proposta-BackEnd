namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IStatusPropostaRepository"/>.
    /// </summary>
    public class StatusPropostaRepository : BaseRepository<StatusProposta>, IStatusPropostaRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StatusPropostaRepository"/> class.
        ///     Construtor padrão de <see cref="StatusPropostaRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public StatusPropostaRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
