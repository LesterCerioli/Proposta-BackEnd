namespace Propostas.Application.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PropostaViewModel : BaseViewModel
    {
        public Guid Codigo { get; set; }
        public int Versao { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string DataPropostaAlteracao { get; set; }
        public string UrlArquivo { get; set; }

        public int TemplateId { get; set; }
        public int ClienteId { get; set; }

        public ICollection<PropostaTagViewModel> PropostaTags { get; set; }
    }
}
