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
        ///     O c�digo do State.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        [DisplayName("UF")]
        public string Uf { get; set; }

        /// <summary>
        ///     O c�digo do IBGE do Estado.
        /// </summary>
        [Required]
        [DisplayName("C�digo IBGE")]
        public int CodigoIbge { get; set; }

        /// <summary>
        ///     O pa�s onde o State se localiza.
        /// </summary>
        [Required]
        [DisplayName("Pa�s")]
        public PaisViewModel Pais { get; set; }
    }
}
