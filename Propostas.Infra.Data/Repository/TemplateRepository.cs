namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ITemplateRepository"/>.
    /// </summary>
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TemplateRepository"/> class.
        ///     Construtor padrão de <see cref="TemplateRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public TemplateRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
