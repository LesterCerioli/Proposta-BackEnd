namespace Propostas.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Propostas.Application.Filters;
    using Propostas.Application.Interfaces;
    using Propostas.Application.ViewModels;
    using Propostas.Domain.Models;
    using Propostas.Infra.CrossCutting.Core.Messages;
    using System;
    using System.Net;

    [Produces("application/json")]
    [Route("[controller]")]
    public abstract class BaseController<TViewModel, TFilter, TEntity> : ControllerBase
        where TViewModel : BaseViewModel
        where TFilter : BaseFilter
        where TEntity : BaseEntity
    {
        public string ErrorCode;
        protected readonly IBaseAppService<TViewModel, TFilter, TEntity> appService;

        protected BaseController(IBaseAppService<TViewModel, TFilter, TEntity> appService)
        {
            this.appService = appService;
        }

        protected new IActionResult Response(
            object result = null,
            HttpStatusCode statusCode = HttpStatusCode.OK,
            string message = "")
        {
            var response = new ResponseViewModel()
            {
                Data = result,
                Message = message,
                Success = false
            };

            if (result != null)
            {
                // Handled Error
                if (result.GetType() == typeof(PropostasException))
                {
                    response.Message = (result as PropostasException).Message;

                    return new ObjectResult(response)
                    { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                // Unhandled Error
                if (result is Exception)
                {
                    response.Message = Messages.InternalServerError;

                    return new ObjectResult(response)
                    { StatusCode = (int)HttpStatusCode.InternalServerError };
                }

                // Success
                if (result is ResponseViewModel)
                {
                    ((ResponseViewModel)result).Success = true;
                    return new ObjectResult(result)
                    { StatusCode = (int)statusCode };
                }
            }

            response.Success = true;

            return new ObjectResult(response)
            { StatusCode = (int)statusCode };
        }

        /// <summary>
        ///     Obtém o registro cujo ID (Primary Key) é o passado como parâmetro.
        /// </summary>
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            try
            {
                var item = this.appService.GetById(id);
                return this.Response(item);
            }
            catch (PropostasException emx)
            {
                return this.Response(emx);
            }
            catch (Exception ex)
            {
                return this.Response(ex);
            }
        }

        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        [HttpGet]
        public virtual IActionResult Get(TFilter filter)
        {
            try
            {
                var results = this.appService.GetBy(filter);
                return this.Response(results);
            }
            catch (PropostasException emx)
            {
                return this.Response(emx);
            }
            catch (Exception ex)
            {
                return this.Response(ex);
            }
        }

        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        [HttpGet("all")]
        public virtual IActionResult Get()
        {
            try
            {
                var results = this.appService.GetAll();
                return this.Response(results);
            }
            catch (PropostasException emx)
            {
                return this.Response(emx);
            }
            catch (Exception ex)
            {
                return this.Response(ex);
            }
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] TViewModel obj)
        {
            try
            {
                var _added = this.appService.Add(obj);
                return this.Response(_added, HttpStatusCode.Created, Messages.SaveSuccess);
            }
            catch (PropostasException emx)
            {
                return this.Response(emx);
            }
            catch (Exception ex)
            {
                return this.Response(ex);
            }
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put([FromBody] TViewModel obj)
        {
            try
            {
                this.appService.Update(obj);
                return this.Response(obj, HttpStatusCode.OK, Messages.UpdateSuccess);
            }
            catch (PropostasException emx)
            {
                return this.Response(emx);
            }
            catch (Exception ex)
            {
                return this.Response(ex);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            try
            {
                this.appService.Remove(id);
                return this.Response(id, HttpStatusCode.OK, Messages.DeleteSuccess);
            }
            catch (PropostasException emx)
            {
                return this.Response(emx);
            }
            catch (Exception ex)
            {
                return this.Response(ex);
            }
        }

        [HttpGet("status/{id}")]
        public virtual IActionResult ModificaAtivo(int id)
        {
            try
            {
                this.appService.ModificaStatus(id);
                return this.Response(id, HttpStatusCode.OK, Messages.UpdateSuccess);
            }
            catch (PropostasException emx)
            {
                return this.Response(emx);
            }
            catch (Exception ex)
            {
                return this.Response(ex);
            }
        }
    }
}
