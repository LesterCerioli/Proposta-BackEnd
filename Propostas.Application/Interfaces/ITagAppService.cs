namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Tag Application Service
    /// </summary>
    public interface ITagAppService : IBaseAppService<TagViewModel, TagFilter, Tag>
    {
    }
}
