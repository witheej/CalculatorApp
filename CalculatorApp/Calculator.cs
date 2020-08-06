using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorApp
{
    // NOTE: Assumes a 2-argument expression for simplicity
    // NOTE: Assumes positive numbers for simplicity
    public static class Calculator
    {
        public static string AcceptableArgumentPattern = @"[0-9]+(\.[0-9]+)?";
        public static string OperatorPattern = @"\s*[-+/*]\s*";
        public static Regex InputRegex = new Regex(@"\A(?!0+[1-9+])" + AcceptableArgumentPattern + @"[-+/*]" + AcceptableArgumentPattern + @"\Z");
        public static char[] OperatorSymbols =  { '+', '-', '*', '/' };
        public static string ComputeResults(string input)
        {
            try
            {
                if (!IsInputValid(input))
                    return "ERROR";

                double[] arguments = GetArguments(input);
                string operatorSymbol = GetSingleOperatorSymbol(input);
                BinaryOperator<double> binaryOperator = BinaryOperatorFactory.Create(operatorSymbol);

                double operationResult = binaryOperator.Operate(arguments[0], arguments[1]);

                string resultString = operationResult.ToString();

                return resultString.Substring(0, System.Math.Min(resultString.Length, 10));
            }
            catch (System.Exception e)
            {
                string s = e.ToString();
                return "EXCEPTION";
            }
        }

        public static bool IsInputValid(string input)
        {
            return InputRegex.IsMatch(input);
        }

        public static string GetSingleOperatorSymbol(string input)
        {
            return Regex.Match(input, "[-+/*]").Value;
        }

        public static double[] GetArguments(string input)
        {
            string[] argumentArray = input.Split(OperatorSymbols);
            double[] numericArgumentArray = argumentArray.Select(x => double.Parse(x)).ToArray();

            return numericArgumentArray;
        }
    }
}
