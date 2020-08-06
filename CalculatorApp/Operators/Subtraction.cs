using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp.Operators
{
    public class Subtraction : BinaryOperator<double>
    {
        public override double Operate(double Arg1, double Arg2)
        {
            return Arg1 - Arg2;
        }
    }
}
