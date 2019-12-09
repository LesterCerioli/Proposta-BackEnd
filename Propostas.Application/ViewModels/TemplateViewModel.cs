namespace Propostas.Application.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TemplateViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public int TipoTemplateId { get; set; }
        public int? Versao { get; set; }
        public Guid? Codigo { get; set; }
        
        public ICollection<int?> Secoes { get; set; }
    }
}
