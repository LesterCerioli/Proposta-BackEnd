namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Moeda Application Service
    /// </summary>
    public interface IMoedaAppService : IBaseAppService<MoedaViewModel, MoedaFilter, Moeda>
    {
    }
}
