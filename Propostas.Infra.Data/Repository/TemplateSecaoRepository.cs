namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ITemplateSecaoRepository"/>.
    /// </summary>
    public class TemplateSecaoRepository : BaseRepository<TemplateSecao>, ITemplateSecaoRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TemplateSecaoRepository"/> class.
        ///     Construtor padrão de <see cref="TemplateSecaoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public TemplateSecaoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
