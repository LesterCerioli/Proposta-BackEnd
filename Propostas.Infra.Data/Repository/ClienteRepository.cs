namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IClienteRepository"/>.
    /// </summary>
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ClienteRepository"/> class.
        ///     Construtor padrão de <see cref="ClienteRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public ClienteRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
