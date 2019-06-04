using System;
using Xunit;

namespace xunit.calculatorTests
{
    public class CalculatorTests
    {
        [Fact]
        public void test_add()
        {
            var cal = new Calculator();
            Assert.True(cal.Add(3, 4) == 7, "Cal Add result is 7. ");
        }

        [Fact]
        public void test_subtract()
        {
            var cal = new Calculator();
            Assert.True(cal.Subtract(3, 4) == -1, "Cal subtract result is -1. ");
        }
    }
}
