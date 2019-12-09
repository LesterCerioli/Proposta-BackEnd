namespace Propostas.Application.Interfaces
{
    using Propostas.Application.Filters;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using System;
    using System.Linq.Expressions;

    /// <summary>
    ///     Interface de contrato de Proposta Application Service
    /// </summary>
    public interface IPropostaAppService : IBaseAppService<PropostaViewModel, PropostaFilter, Proposta>
    {
        ResponseViewModel GetByHist(PropostaFilter filter, params Expression<Func<Proposta, object>>[] includes);
    }
}
