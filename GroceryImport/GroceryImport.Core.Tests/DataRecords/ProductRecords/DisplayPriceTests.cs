using FluentAssertions;
using GroceryImport.Core.DataRecords.ProductRecords;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.ProductRecords
{
    [TestClass]
    public class DisplayPriceTests
    {
        [TestMethod, TestCategory("unit")]
        public void MarkerClassShouldHaveCorrectToSystemType()
        {
            //Arrange
            DisplayPrice subject = new TestDisplayPrice("The Value");

            //Act
            string actual = subject;

            //Assert
            actual.Should().Be("The Value");
        }

        private sealed class TestDisplayPrice : DisplayPrice
        {
            private readonly string _value;

            public TestDisplayPrice(string value) => _value = value;

            public override string AsSystemType() => _value;
        }
    }
}