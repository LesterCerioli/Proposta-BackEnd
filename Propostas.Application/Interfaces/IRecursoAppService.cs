namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Recurso Application Service
    /// </summary>
    public interface IRecursoAppService : IBaseAppService<RecursoViewModel, RecursoFilter, Recurso>
    {
    }
}
