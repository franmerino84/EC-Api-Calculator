﻿namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Multiplications.Dtos
{
    public class CalculatorMultiplicationResponseDto
    {
        public CalculatorMultiplicationResponseDto(int product)
        {
            Product = product;
        }

        public int Product { get; }
    }
}
