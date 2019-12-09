namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using System.Collections.Generic;

    /// <summary>
    ///     Interface de contrato de TemplateSecao Application Service
    /// </summary>
    public interface ITemplateSecaoAppService : IBaseAppService<TemplateSecaoViewModel, TemplateSecaoFilter, TemplateSecao>
    {

    }
}
