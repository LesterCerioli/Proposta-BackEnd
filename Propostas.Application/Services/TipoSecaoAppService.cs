namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Implementação da <see cref="ITipoSecaoAppService"/>.
    /// </summary>
    public class TipoSecaoAppService : BaseAppService<TipoSecaoViewModel, TipoSecaoFilter, TipoSecao>, ITipoSecaoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TipoSecaoAppService"/> class.
        ///     Construtor padrão de <see cref="TipoSecaoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade TipoSecao. Veja <see cref="ITipoSecaoRepository"/>.
        /// </param>

        public TipoSecaoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ITipoSecaoRepository repository)
            : base(uow, mapper, repository)
        {
        }

        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        /// <returns>
        ///     Todos os registros do banco de dados.
        /// </returns>
        public override IEnumerable<TipoSecaoViewModel> GetAll()
        {
            var results = this.repository.GetBy(null, ts => ts.Secoes).ToList();
            return this.mapper.Map<IEnumerable<TipoSecaoViewModel>>(results);
        }
    }
}
