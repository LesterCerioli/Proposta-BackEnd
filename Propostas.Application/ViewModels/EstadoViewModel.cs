namespace Propostas.Application.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class EstadoViewModel : BaseViewModel
    {
        /// <summary>
        ///     O nome do State.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        /// <summary>
        ///     O código do State.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        [DisplayName("UF")]
        public string Uf { get; set; }

        /// <summary>
        ///     O código do IBGE do Estado.
        /// </summary>
        [Required]
        [DisplayName("Código IBGE")]
        public int CodigoIbge { get; set; }

        /// <summary>
        ///     O país onde o State se localiza.
        /// </summary>
        [Required]
        [DisplayName("País")]
        public PaisViewModel Pais { get; set; }
    }
}
