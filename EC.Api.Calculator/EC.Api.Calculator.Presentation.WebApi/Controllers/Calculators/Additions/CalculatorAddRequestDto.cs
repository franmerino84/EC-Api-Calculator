﻿using EC.Api.Calculator.Infrastructure.Validation.Validators;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions
{
    public class CalculatorAddRequestDto
    {
        public CalculatorAddRequestDto(List<int> addends)
        {
            Addends = addends;
        }

        [EnsureMinimumElements(2, ErrorMessage = $"{nameof(Addends)} must contain at least two addends")]
        public List<int> Addends { get; }
    }
}
