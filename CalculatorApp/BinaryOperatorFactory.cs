using CalculatorApp.Operators;
using System;

namespace CalculatorApp
{
    public static class BinaryOperatorFactory
    {
        public static BinaryOperator<double> Create(string @operator)
        {
            BinaryOperator<double> result = @operator switch
            {
                "+" => new Addition(),
                "-" => new Subtraction(),
                "*" => new Multiplication(),
                "/" => new Division(),
                _ => throw new Exception($"{@operator} is not a valid operator")
            };

            return result;
        }
    }
}
