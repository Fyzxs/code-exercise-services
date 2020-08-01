using FluentAssertions;
using GroceryImport.Core.DataRecords.ProductRecords;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.ProductRecords
{
    [TestClass]
    public class UnitOfMeasureTests
    {
        [TestMethod, TestCategory("unit")]
        public void MarkerClassShouldHaveCorrectToSystemType()
        {
            //Arrange
            UnitOfMeasure subject = new TestUnitOfMeasure("The Value");

            //Act
            string actual = subject;

            //Assert
            actual.Should().Be("The Value");
        }

        private sealed class TestUnitOfMeasure : UnitOfMeasure
        {
            private readonly string _value;

            public TestUnitOfMeasure(string value) => _value = value;

            public override string AsSystemType() => _value;
        }
    }
}