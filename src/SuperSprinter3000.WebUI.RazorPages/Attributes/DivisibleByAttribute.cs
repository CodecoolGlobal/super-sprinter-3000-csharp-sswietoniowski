using System.ComponentModel.DataAnnotations;

namespace SuperSprinter3000.WebUI.RazorPages.Attributes;

public class DivisibleByAttribute : ValidationAttribute
{
    private readonly decimal _divisor;

    public DivisibleByAttribute(double divisor)
    {
        _divisor = (decimal)divisor;
    }

    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            return false;
        }

        decimal number = value switch
        {
            int intValue => intValue,
            decimal decimalValue => decimalValue,
            _ => throw new ArgumentException("Value must be an integer or decimal number.", nameof(value))
        };

        return number % _divisor == 0;
    }
}