namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Produto Application Service
    /// </summary>
    public interface IProdutoAppService : IBaseAppService<ProdutoViewModel, ProdutoFilter, Produto>
    {
    }
}
