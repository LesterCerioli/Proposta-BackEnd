namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de Secao Application Service
    /// </summary>
    public interface ISecaoArquivoAppService : IBaseAppService<SecaoArquivoViewModel, SecaoArquivoFilter, SecaoArquivo>
    {
        void RemovePorSecao(int id, bool commit = false);
    }
}
