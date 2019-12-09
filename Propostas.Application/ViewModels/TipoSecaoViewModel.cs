namespace Propostas.Application.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TipoSecaoViewModel : BaseViewModel
    {

        public string Nome { get; set; }
        public string Obrigatorio { get; set; }
        public string Formato { get; set; }

        public ICollection<SecaoViewModel> Secoes { get; set; }
    }
}
