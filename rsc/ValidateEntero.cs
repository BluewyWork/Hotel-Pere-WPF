using System.Globalization;
using System.Windows.Controls;

namespace WpfAppIntermodular.rsc
{
    class ValidateEntero : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i;
            if (int.TryParse(value.ToString(), out i))
            {
                return new ValidationResult(true, null);

            }
            else
            {
                return new ValidationResult(false, "Debe introducir un numero entero");
            }
        }
    }
}
