namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    ///     Interface de contrato de Template Application Service
    /// </summary>
    public interface ITemplateAppService : IBaseAppService<TemplateViewModel, TemplateFilter, Template>
    {
        ResponseViewModel GetByHist(TemplateFilter filter, params Expression<Func<Template, object>>[] includes);

        IEnumerable<TagViewModel> GetByTags(int id);

    }
}
