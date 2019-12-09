namespace Propostas.Application.Pagers
{
    using Propostas.Domain.Interfaces;

    public class Pager : IPager
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPagination { get; set; }
    }
}
