using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_BookShelf
{
    public class NumberNotValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long number;
            try
            {
                if (value != null)
                {
                    number = Int64.Parse(value.ToString());
                } 
                else
                {
                    return new ValidationResult(false, "ISBN not valid, must be a number");
                }
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
            int digits = (int)Math.Floor(Math.Log10(number) + 1);
            if (digits != 13 && digits != 10)
                return new ValidationResult(false, "ISBN must contain 13 or 10 digits");


            return ValidationResult.ValidResult;
        }
    }
}
