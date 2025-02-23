using System.ComponentModel.DataAnnotations;

namespace ApiCatalago.Validations;

public class FirstLetterCaseAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((value is null || string.IsNullOrEmpty(value.ToString())))
            return ValidationResult.Success;
        
        return base.IsValid(value, validationContext);
    }
}