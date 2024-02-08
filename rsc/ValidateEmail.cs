using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WpfAppIntermodular.rsc
{
    public class ValidateEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            //string cadena = value.ToString();
            if (regex.IsMatch(value.ToString())/*cadena.Contains("@")*/)
            {
                return new ValidationResult(true, null);

            }
            else
            {
                return new ValidationResult(false, "Debe introducir un email válido");
            }
        }
    }
}
