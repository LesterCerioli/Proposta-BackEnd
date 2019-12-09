namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Secao Application Service
    /// </summary>
    public interface ISecaoAppService : IBaseAppService<SecaoViewModel, SecaoFilter, Secao>
    {
    }
}
