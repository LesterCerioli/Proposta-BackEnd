namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de TipoTemplate Application Service
    /// </summary>
    public interface ITipoTemplateAppService : IBaseAppService<TipoTemplateViewModel, TipoTemplateFilter, TipoTemplate>
    {
    }
}
