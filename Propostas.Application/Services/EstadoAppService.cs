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
    ///     Implementação da <see cref="IEstadoAppService"/>.
    /// </summary>
    public class EstadoAppService : BaseAppService<EstadoViewModel, EstadoFilter, Estado>, IEstadoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoAppService"/> class.
        ///     Construtor padrão de <see cref="EstadoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="bus">
        ///     Barramento de comandos. Veja <see cref="IMediatorHandler"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Estado. Veja <see cref="IEstadoRepository"/>.
        /// </param>
        public EstadoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IEstadoRepository repository)
            : base(uow, mapper, repository)
        {
        }

        /// <summary>
        ///     Obtém o registro cujo ID é o passado como parâmetro.
        /// </summary>
        public override EstadoViewModel GetById(int id)
        {
            var result = this.repository.GetBy(c => c.Id == id, c => c.Pais).FirstOrDefault();
            return this.mapper.Map<EstadoViewModel>(result);
        }

        /// <summary>
        ///     Obtém todos os estados do país informado.
        /// </summary>
        /// <param name="id">
        ///     Id do país.
        /// </param>
        /// <returns>
        ///     Todos os Estados do Banco de Dados. Veja See <see cref="EstadoViewModel"/>.
        /// </returns>
        public IEnumerable<EstadoViewModel> GetByPais(int id)
        {
            var results = this.repository.GetByOrdered(est => est.PaisId == id, est => est.Nome, true).ToList();
            return this.mapper.Map<IEnumerable<EstadoViewModel>>(results);
        }
    }
}
