namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de TiposContato Application Service
    /// </summary>
    public interface ITiposContatoAppService : IBaseAppService<TiposContatoViewModel, TiposContatoFilter, TiposContato>
    {
    }
}
