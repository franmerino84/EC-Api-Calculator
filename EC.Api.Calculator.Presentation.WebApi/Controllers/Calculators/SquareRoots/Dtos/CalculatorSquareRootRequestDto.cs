﻿namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots.Dtos
{
    public class CalculatorSquareRootRequestDto
    {
        public CalculatorSquareRootRequestDto(int number)
        {
            Number = number;
        }

        public int Number { get; }
    }
}
