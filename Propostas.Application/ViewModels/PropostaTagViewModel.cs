namespace Propostas.Application.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class PropostaTagViewModel : BaseViewModel
    {
        public string Chave { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string Base64 { get; set; }
    }
}
