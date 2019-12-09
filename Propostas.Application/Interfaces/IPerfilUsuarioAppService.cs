namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Interface de contrato de PerfilUsuario Application Service
    /// </summary>
    public interface IPerfilUsuarioAppService : IBaseAppService<PerfilUsuarioViewModel, PerfilUsuarioFilter, PerfilUsuario>
    {
    }
}
