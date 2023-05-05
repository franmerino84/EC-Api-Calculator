using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace EC.Api.Calculator.Infrastructure.Validation.Validators
{
    public class EnsureMinimumElementsAttribute : ValidationAttribute
    {
        private readonly int _minimumElements;
        public EnsureMinimumElementsAttribute(int minimumElements)
        {
            _minimumElements = minimumElements;
        }
        public override bool IsValid(object? value)
        {
            if (value is IList list)
                return list.Count >= _minimumElements;

            return false;
        }
    }
}
