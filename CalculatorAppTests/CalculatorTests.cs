using System;
using System.Linq;
using Xunit;

namespace CalculatorApp.Tests
{
    public class CalculatorTests
    {
        [Theory()]
        [InlineData("2129.2", "532.3*4")]
        [InlineData("111.411629", "532.3/4.7777777")]
        [InlineData("NaN", "0/0")]
        [InlineData("10000", "10000-0")]
        [InlineData("1", "1+0")]
        [InlineData("ERROR", "532.3.*4")]
        [InlineData("ERROR", "1/4.")]
        [InlineData("ERROR", "10./0")]
        [InlineData("ERROR", "100000")]
        [InlineData("ERROR", "")]
        public void ComputeResultsTest(string expectedResult, string input)
        {
            string result = Calculator.ComputeResults(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory()]
        [InlineData(true, "532.3*4")]
        [InlineData(true, "532.3/4.7777777")]
        [InlineData(true, "0/0")]
        [InlineData(true, "10000-0")]
        [InlineData(true, "1+0")]
        [InlineData(false, "532.3.*4")]
        [InlineData(false, "1/4.")]
        [InlineData(false, "10./0")]
        [InlineData(false, "100000")]
        [InlineData(false, "")]
        public void IsInputValidTest(bool expectedResult, string input)
        {
            Assert.Equal(expectedResult, Calculator.IsInputValid(input));
        }

        [Theory()]
        [InlineData("532.3*4")]
        [InlineData("532.3/4.7777777")]
        [InlineData("0/0")]
        [InlineData("10000-0")]
        [InlineData("1+0")]
        public void GetSingleOperatorSymbolTest(string input)
        {
            string result = Calculator.GetSingleOperatorSymbol(input);

            Assert.True(result.Length == 1);
            Assert.True(Calculator.OperatorSymbols.Contains(result.ToCharArray()[0]));
        }

        [Theory()]
        [InlineData("532.3*4")]
        [InlineData("532.3/4.7777777")]
        [InlineData("0/0")]
        [InlineData("10000-0")]
        [InlineData("1+0")]
        public void GetArgumentsTest(string input)
        {
            double[] arguments = Calculator.GetArguments(input);

            Assert.True(arguments.Length == 2, "Expected exactly 2 arguments");

            string[] args = input.Split(Calculator.OperatorSymbols);

            // TODO: check parsing into doubles
        }
    }
}