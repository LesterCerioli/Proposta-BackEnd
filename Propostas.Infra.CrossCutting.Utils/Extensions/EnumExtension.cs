namespace Propostas.Infra.CrossCutting.Utils.Extensions
{
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumExtension
    {
        public static string GetDescription<T>(this T value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
