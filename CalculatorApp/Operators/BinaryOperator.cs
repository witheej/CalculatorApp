using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public abstract class BinaryOperator<T>
    {
        public abstract T Operate(T Arg1, T Arg2);
    }
}
