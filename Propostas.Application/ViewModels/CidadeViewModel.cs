namespace Propostas.Application.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CidadeViewModel : BaseViewModel
    {
        /// <summary>
        ///     O nome da Cidade.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("Cidade")]
        public string Nome { get; set; }

        /// <summary>
        ///     O código do IBGE da Cidade.
        /// </summary>
        [Required]
        [DisplayName("Código IBGE")]
        public int CodigoIbge { get; set; }

        /// <summary>
        ///     O estado onde a Cidade se localiza.
        /// </summary>
        [Required]
        [DisplayName("Estado")]
        public EstadoViewModel Estado { get; set; }
    }
}
