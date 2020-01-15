using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_BookShelf
{
    public class CategoryNotValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Category category;
            try
            {
                category = (Category)Enum.Parse(typeof(Category), value.ToString());
            }
            catch (ArgumentException)
            {
                return new ValidationResult(false, "Category not recognized");
            }
            return ValidationResult.ValidResult;
        }
    }
}
