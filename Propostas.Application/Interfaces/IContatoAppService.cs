namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Contato Application Service
    /// </summary>
    public interface IContatoAppService : IBaseAppService<ContatoViewModel, ContatoFilter, Contato>
    {
    }
}
