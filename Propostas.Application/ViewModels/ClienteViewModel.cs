namespace Propostas.Application.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ClienteViewModel : BaseViewModel
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
    }
}
