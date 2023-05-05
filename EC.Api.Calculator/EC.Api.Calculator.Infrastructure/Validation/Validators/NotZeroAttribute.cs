using System.ComponentModel.DataAnnotations;

namespace EC.Api.Calculator.Infrastructure.Validation.Validators
{
    public class NotZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value) => 
            value != null && (int)value != 0;
    }
}
