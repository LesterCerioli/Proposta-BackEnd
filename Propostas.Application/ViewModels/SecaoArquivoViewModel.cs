namespace Propostas.Application.ViewModels
{
    public class SecaoArquivoViewModel : BaseViewModel
    {
        public int SecaoId { get; set; }
        public int? Versao { get; set; }
        public string Nome { get; set; }
        public string Base64Arquivo { get; set; }
        public string UrlArquivo { get; set; }
    }
}
