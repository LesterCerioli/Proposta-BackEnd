namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Implementação da <see cref="ITemplateSecaoAppService"/>.
    /// </summary>
    public class TemplateSecaoAppService : BaseAppService<TemplateSecaoViewModel, TemplateSecaoFilter, TemplateSecao>, ITemplateSecaoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateSecaoAppService"/> class.
        ///     Construtor padrão de <see cref="TemplateSecaoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade TemplateSecao. Veja <see cref="ITemplateSecaoRepository"/>.
        /// </param>

        public TemplateSecaoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ITemplateSecaoRepository repository)
            : base(uow, mapper, repository)
        {
        }



    }
}
