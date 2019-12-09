namespace Propostas.Application.Services
{
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.Pagers;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Enumerators;
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.CrossCutting.Core.Messages;
    using Propostas.Infra.CrossCutting.Utils.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class BaseAppService<TViewModel, TFilter, TEntity> : IBaseAppService<TViewModel, TFilter, TEntity>
        where TViewModel : BaseViewModel
        where TFilter : BaseFilter
        where TEntity : BaseEntity
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork uow;
        protected readonly IBaseRepository<TEntity> repository;

        public BaseAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IBaseRepository<TEntity> repository)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.repository = repository;
        }

        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        /// <returns>
        ///     Todos os registros do banco de dados.
        /// </returns>
        public virtual IEnumerable<TViewModel> GetAll()
        {
            var results = this.repository.GetAll();
            return results.ProjectTo<TViewModel>().ToList();
        }

        /// <summary>
        ///     Obtém o registro cujo ID é o passado como parâmetro.
        /// </summary>
        public virtual TViewModel GetById(int id)
        {
            var result = this.repository.GetBy(c => c.Id == id).FirstOrDefault();
            return this.mapper.Map<TViewModel>(result);
        }

        /// <summary>
        ///     Obtém os registros utilizando o filtro utilizado no parâmetro.
        /// </summary>
        public virtual ResponseViewModel GetBy(TFilter filter, params Expression<Func<TEntity, object>>[] includes)
        {
            #region Filters 

            var expression = PredicateBuilder.True<TEntity>();

            if (filter != null)
            {
                if (filter.Id.HasValue)
                {
                    expression = expression.And(f => f.Id == filter.Id.Value);
                }

                if (filter.Ativo.HasValue)
                {
                    expression = expression.And(f => f.Ativo == filter.Ativo.Value);
                }
            }

            #endregion Filters 

            #region OrderBy

            Func<TEntity, object> orderBy;
            filter.SortBy = filter.SortBy ?? string.Empty;
            switch (filter.SortBy.ToLower())
            {
                case "ativo":
                    orderBy = (x => x.Ativo);
                    break;
                default:
                    orderBy = (x => x.Id);
                    break;
            }

            var orderByDirection = OrderByDirectionEnum.Ascending;
            if (filter.SortDirection.ToLowerCase() == "desc")
            {
                orderByDirection = OrderByDirectionEnum.Descending;
            }

            #endregion OrderBy

            #region Pager

            var pager = new Pager()
            {
                PageNumber = filter.PageNumber ?? 0,
                PageSize = filter.PageSize ?? 25,
                HasPagination = filter.HasPagination
            };

            #endregion Pager

            var query = this.repository.GetBy(expression, includes);
            var results = this.repository.GetByPaged(query, orderBy, orderByDirection, pager).ToList();

            var totalItems = this.repository.Count(expression);
            var totalPages = 1;
            if (filter.HasPagination)
            {
                if (filter.PageSize.HasValue)
                {
                    var ceilingResult = Math.Ceiling((decimal)totalItems / (decimal)filter.PageSize.Value);
                    totalPages = int.Parse(ceilingResult.ToString());
                }
            }

            var response = new ResponseViewModel
            {
                Data = this.mapper.Map<IEnumerable<TViewModel>>(results),
                Page = new PageViewModel
                {
                    PageNumber = filter.HasPagination ? (filter.PageNumber ?? 1) : 1,
                    Size = filter.HasPagination ? (filter.PageSize ?? totalItems) : totalItems,
                    TotalElements = totalItems,
                    TotalPages = totalPages
                },
                Success = true
            };

            return response;
        }

        /// <summary>
        ///     Obtém os registros utilizando a expressão utilizada no parâmetro.
        /// </summary>
        public virtual IEnumerable<TViewModel> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            var results = this.repository.GetBy(expression).ToList();
            return this.mapper.Map<IEnumerable<TViewModel>>(results);
        }

        /// <summary>
        ///     Obtém os registros utilizando a expressão utilizada no parâmetro.
        /// </summary>
        public virtual IEnumerable<TViewModel> GetBy(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            var results = this.repository.GetBy(expression, includes).ToList();
            return this.mapper.Map<IEnumerable<TViewModel>>(results);
        }

        /// <summary>
        ///     Salva o registro passado como parâmetro.
        /// </summary>
        public virtual TViewModel Add(TViewModel model, bool commit = true)
        {
            var entity = this.mapper.Map<TEntity>(model);
            this.repository.Add(entity);

            this.Commit(commit);

            model.Id = entity.Id;

            return model;
        }

        /// <summary>
        ///     Atualiza o registro passado como parâmetro.
        /// </summary>
        public virtual void Update(TViewModel model, bool commit = true)
        {
            if (model.Id == 0)
            {
                throw new PropostasException(Messages.NotFound);
            }

            var entity = this.mapper.Map<TEntity>(model);
            this.repository.Update(entity);
            this.Commit(commit);
        }

        /// <summary>
        ///     Remove o registro que possui o identificador passado no parâmetro.
        /// </summary>
        public virtual void Remove(int id, bool commit = true)
        {
            var entity = this.repository.GetById(id);
            if (entity == null)
            {
                throw new PropostasException(Messages.NotFound);
            }

            this.repository.Remove(id);
            this.Commit(commit);
        }

        /// <summary>
        /// Altera o status do registro
        /// </summary>
        public virtual void ModificaStatus(int id, bool commit = true)
        {
            var entity = this.repository.GetById(id);
            if (entity == null)
            {
                throw new PropostasException(Messages.NotFound);
            }

            entity.Ativo = !entity.Ativo;
            this.repository.Update(entity);
            this.Commit(commit);
            
        }

        public virtual void Commit(bool commit)
        {
            if (commit)
            {
                this.uow.Commit();
            }
        }

        /// <summary>
        ///     Desaloca os recursos de Cidade Application Service usando o Garbage Collector.
        /// </summary>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
