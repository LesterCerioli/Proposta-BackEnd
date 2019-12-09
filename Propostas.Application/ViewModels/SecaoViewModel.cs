namespace Propostas.Application.ViewModels
{
    using System;

    public class SecaoViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public bool Editavel { get; set; }
        public int LinguagemId { get; set; }
        public int TipoSecaoId { get; set; }
        public int PublicoAlvoId { get; set; }
        public int Ordem { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int? UsuarioAlteracaoId { get; set; }

        public SecaoArquivoViewModel SecaoArquivo { get; set; }
        
    }
}
