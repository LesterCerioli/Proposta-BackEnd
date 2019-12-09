namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class SecaoArquivoRepository: BaseRepository<SecaoArquivo>, ISecaoArquivoRepository
    {
   
        /// <summary>
        ///     Initializes a new instance of the <see cref="SecaoRepository"/> class.
        ///     Construtor padrão de <see cref="SecaoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public SecaoArquivoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
