using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_BookShelf
{
    public class IdNotValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long number;
            try
            {
                number = Int64.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "ISBN not valid, must be a number");
            }
            catch (OverflowException)
            {
                return new ValidationResult(false, "ISBN not valid, too long or too short");
            }
            if (number < 0)
                return new ValidationResult(false, "ISBN must be an positive number");


            return ValidationResult.ValidResult;
        }
    }
}
