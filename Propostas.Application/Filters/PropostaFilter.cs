namespace Propostas.Application.Filters
{
    using System;

    public class PropostaFilter : BaseFilter
    {
        public bool? LastVersion { get; set; }
        public Guid? Codigo { get; set; }
    }
}
