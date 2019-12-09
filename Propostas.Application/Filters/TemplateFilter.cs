using System;

namespace Propostas.Application.Filters
{
    public class TemplateFilter : BaseFilter
    {
        public bool? LastVersion { get; set; }
        public Guid? Codigo { get; set; }
    }
}
