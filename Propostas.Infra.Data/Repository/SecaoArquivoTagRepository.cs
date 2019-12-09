namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ISecaoArquivoTagRepository"/>.
    /// </summary>
    public class SecaoArquivoTagRepository : BaseRepository<SecaoArquivoTag>, ISecaoArquivoTagRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SecaoArquivoTagRepository"/> class.
        ///     Construtor padrão de <see cref="SecaoArquivoTagRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public SecaoArquivoTagRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
