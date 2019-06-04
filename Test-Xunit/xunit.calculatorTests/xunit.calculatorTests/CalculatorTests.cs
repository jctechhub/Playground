using System;
using Xunit;

namespace xunit.calculatorTests
{
    public class CalculatorFixture
    {
        public Calculator Calc => new Calculator();

    }


    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private CalculatorFixture _calculatorFixture;

        public CalculatorTests(CalculatorFixture calculatorFixture)
        {
            _calculatorFixture = calculatorFixture;
        }

        [Fact]
        [Trait("CalCategory", "Add")]
        public void test_add_success()
        {
            Assert.True(_calculatorFixture.Calc.Add(3, 4) == 7, "Cal Add result is 7. ");
        }

        [Fact]
        [Trait("CalCategory", "Add")]
        public void test_add_fail()
        {
            Assert.False(_calculatorFixture.Calc.Add(3, 4) == 10, "Cal Add result isn't 10. ");
        }



        [Fact]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_success()
        {
            Assert.True(_calculatorFixture.Calc.Subtract(3, 4) == -1, "Cal subtract result is -1. ");
        }

        [Fact]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_fail()
        {
            Assert.False(_calculatorFixture.Calc.Subtract(3, 4) == -10, "Cal subtract result isnot  -10. ");
        }


        [Theory]
        [InlineData(3,4, -1, true)]
        [InlineData(3, 4, -10, false)]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_generic(int x, int y, int result, bool expected)
        {
            var check = _calculatorFixture.Calc.Subtract(x, y) == result;
            Assert.Equal(check, expected);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.AddOrSubtractDataFromTextFile), MemberType = typeof(TestDataShare))]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_generic_using_share_data(int x, int y, int result, bool expected)
        {
            var check = _calculatorFixture.Calc.Subtract(x, y) == result;
            Assert.Equal(check, expected);
        }

    }
}
