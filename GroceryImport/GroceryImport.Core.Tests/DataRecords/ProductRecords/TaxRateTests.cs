using FluentAssertions;
using GroceryImport.Core.DataRecords.ProductRecords;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.ProductRecords
{
    [TestClass]
    public class TaxRateTests
    {
        [TestMethod, TestCategory("unit")]
        public void AsSystemType_ShouldReturnZeroForNonTaxable()
        {
            //Arrange
            TaxRate subject = new TestTaxRate(false, double.MaxValue);

            //Act
            double actual = subject;

            //Assert
            actual.Should().Be(0.0d);
        }
        [TestMethod, TestCategory("unit")]
        public void AsSystemType_ShouldReturnProvidedTaxRate()
        {
            //Arrange
            TaxRate subject = new TestTaxRate(true, 0.01234);

            //Act
            double actual = subject;

            //Assert
            actual.Should().Be(0.01234d);
        }

        private sealed class TestTaxRate : TaxRate
        {
            public TestTaxRate(bool isTaxable, double rate) : base(isTaxable, rate)
            {
            }
        }
    }
}