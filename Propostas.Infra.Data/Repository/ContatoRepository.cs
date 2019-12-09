namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IContatoRepository"/>.
    /// </summary>
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ContatoRepository"/> class.
        ///     Construtor padrão de <see cref="ContatoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public ContatoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
