using System;
using System.Collections;
using System.Collections.Generic;

namespace xunit.calculatorTests
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> AddOrSubtractData
        {
            get
            {
                yield return new object[] {3, 4, -1, true};
                yield return new object[] { 3, 4, 10, false };
            }

        }
    }
}
