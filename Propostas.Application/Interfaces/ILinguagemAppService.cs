namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Linguagem Application Service
    /// </summary>
    public interface ILinguagemAppService : IBaseAppService<LinguagemViewModel, LinguagemFilter, Linguagem>
    {
    }
}
