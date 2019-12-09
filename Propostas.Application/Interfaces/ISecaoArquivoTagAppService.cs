namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de SecaoArquivoTag Application Service
    /// </summary>
    public interface ISecaoArquivoTagAppService : IBaseAppService<SecaoArquivoTagViewModel, SecaoArquivoTagFilter, SecaoArquivoTag>
    {
    }
}
