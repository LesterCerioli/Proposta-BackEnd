namespace Propostas.Domain.Enumerators
{
    using System.ComponentModel;

    public enum TagTipoEnum
    {
        [Description("texto")]
        Texto = 1,

        [Description("imagem")]
        Imagem = 2
    }
}