using System.ComponentModel.DataAnnotations;

namespace ApiCatalago.Validations;

public class FirstLetterCaseAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var primeiraLetra = String.Empty;

        if (value is null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success ?? ValidationResult.Success!; 
        }
        
        if (!string.IsNullOrEmpty(value.ToString()))
        {
            primeiraLetra = value.ToString()![0].ToString();
        }
        else{
            return new ValidationResult("Não pode ser vazio o nome");
        }

        if (primeiraLetra != primeiraLetra.ToUpper())
        {
            return new ValidationResult("A primeira letra deve ser maiuscula");
        }
        
        return ValidationResult.Success ?? ValidationResult.Success!; 
    }
}