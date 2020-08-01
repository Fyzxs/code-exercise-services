using FluentAssertions;
using GroceryImport.Core.DataRecords.ProductRecords;
using GroceryImport.Core.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.ProductRecords
{
    [TestClass]
    public class CalculatorPriceTests
    {
        [TestMethod, TestCategory("unit")]
        public void MarkerClassShouldHaveCorrectToSystemType()
        {
            //Arrange
            CalculatorPrice subject = new TestCalculatorPrice(1.1m);

            //Act
            decimal actual = subject;

            //Assert
            actual.Should().Be(1.1m);
        }

        private sealed class TestCalculatorPrice : CalculatorPrice
        {
            private readonly decimal _value;

            public TestCalculatorPrice(decimal value) => _value = value;

            public override decimal AsSystemType() => _value;
        }
    }
}