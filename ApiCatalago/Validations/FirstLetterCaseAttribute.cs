using System.ComponentModel.DataAnnotations;

namespace ApiCatalago.Validations;

public class FirstLetterCaseAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((value is null || string.IsNullOrEmpty(value.ToString())))
            return ValidationResult.Success;
        
        var primeiraLetra = value.ToString()[0].ToString();

        if (primeiraLetra != primeiraLetra.ToUpper())
        {
            return new ValidationResult("A primeira letra deve ser maiuscula");
        }
        
        return ValidationResult.Success;
    }
}