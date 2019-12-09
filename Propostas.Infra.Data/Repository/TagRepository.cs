namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ITagRepository"/>.
    /// </summary>
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TagRepository"/> class.
        ///     Construtor padrão de <see cref="TagRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public TagRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
