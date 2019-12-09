namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="ISecaoArquivoTagAppService"/>.
    /// </summary>
    public class SecaoArquivoTagAppService : BaseAppService<SecaoArquivoTagViewModel, SecaoArquivoTagFilter, SecaoArquivoTag>, ISecaoArquivoTagAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecaoArquivoTagAppService"/> class.
        ///     Construtor padrão de <see cref="SecaoArquivoTagAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade SecaoArquivoTag. Veja <see cref="ISecaoArquivoTagRepository"/>.
        /// </param>

        public SecaoArquivoTagAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ISecaoArquivoTagRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
