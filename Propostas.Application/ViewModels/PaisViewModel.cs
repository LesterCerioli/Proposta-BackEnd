namespace Propostas.Application.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class PaisViewModel : BaseViewModel
    {
        /// <summary>
        ///     Código do País.
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        /// <summary>
        ///     Nome do País.
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("País")]
        public string Nome { get; set; }
    }
}
