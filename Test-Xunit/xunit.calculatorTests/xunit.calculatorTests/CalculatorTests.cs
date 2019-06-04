using System;
using Xunit;

namespace xunit.calculatorTests
{
    public class CalculatorTests
    {
        [Fact]
        [Trait("CalCategory", "Add")]
        public void test_add_success()
        {
            var cal = new Calculator();
            Assert.True(cal.Add(3, 4) == 7, "Cal Add result is 7. ");
        }

        [Fact]
        [Trait("CalCategory", "Add")]
        public void test_add_fail()
        {
            var cal = new Calculator();
            Assert.False(cal.Add(3, 4) == 10, "Cal Add result isn't 10. ");
        }



        [Fact]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_success()
        {
            var cal = new Calculator();
            Assert.True(cal.Subtract(3, 4) == -1, "Cal subtract result is -1. ");
        }

        [Fact]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_fail()
        {
            var cal = new Calculator();
            Assert.False(cal.Subtract(3, 4) == -10, "Cal subtract result isnot  -10. ");
        }
    }
}
