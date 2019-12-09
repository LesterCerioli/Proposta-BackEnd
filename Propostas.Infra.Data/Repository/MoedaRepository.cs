namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IMoedaRepository"/>.
    /// </summary>
    public class MoedaRepository : BaseRepository<Moeda>, IMoedaRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MoedaRepository"/> class.
        ///     Construtor padrão de <see cref="MoedaRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public MoedaRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
