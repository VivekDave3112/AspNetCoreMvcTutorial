using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Helpers
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        public string Text;
        public MyCustomValidationAttribute(string text)
        {
            Text = text;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var str = value.ToString();
                if(str.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "Not getting the desired value");
        }
    }
}
