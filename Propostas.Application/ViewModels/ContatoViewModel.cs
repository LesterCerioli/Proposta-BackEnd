namespace Propostas.Application.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ContatoViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Funcao { get; set; }

        public int ClienteId { get; set; }
        public int TipoContatoId { get; set; }

    }
}
