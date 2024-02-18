using System.Globalization;
using System.Windows.Controls;

namespace WpfAppIntermodular.rsc
{
    class ValidateDecimal : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double i;
            if (double.TryParse(value.ToString(), out i))
            {
                return new ValidationResult(true, null);

            }
            else
            {
                return new ValidationResult(false, "Debe introducir un valor decimal");
            }
        }
    }
}
