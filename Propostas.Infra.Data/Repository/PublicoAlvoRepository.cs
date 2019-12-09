namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IPublicoAlvoRepository"/>.
    /// </summary>
    public class PublicoAlvoRepository : BaseRepository<PublicoAlvo>, IPublicoAlvoRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PublicoAlvoRepository"/> class.
        ///     Construtor padrão de <see cref="PublicoAlvoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public PublicoAlvoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
