namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ITipoTemplateRepository"/>.
    /// </summary>
    public class TipoTemplateRepository : BaseRepository<TipoTemplate>, ITipoTemplateRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TipoTemplateRepository"/> class.
        ///     Construtor padrão de <see cref="TipoTemplateRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public TipoTemplateRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
