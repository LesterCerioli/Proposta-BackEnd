namespace Propostas.Application.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class PaisViewModel : BaseViewModel
    {
        /// <summary>
        ///     C�digo do Pa�s.
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        [DisplayName("C�digo")]
        public string Codigo { get; set; }

        /// <summary>
        ///     Nome do Pa�s.
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("Pa�s")]
        public string Nome { get; set; }
    }
}
