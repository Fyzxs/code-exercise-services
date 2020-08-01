using System;
using FluentAssertions;
using GroceryImport.Core.DataRecords.FieldTypes;
using GroceryImport.Core.Exceptions;
using GroceryImport.Core.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    [TestClass]
    public class CurrencyFieldTests
    {
        [TestMethod, TestCategory("unit")]
        public void AsCurrencyString_ShouldBeExpectedFormatForPositiveNumber()
        {
            //Arrange
            CurrencyField subject = new TestCurrencyField(new FakeRecord("00000102"), 0, 0);

            //Act
            string actual = subject.AsCurrencyString();

            //Assert
            actual.Should().Be("$1.02");
        }

        [TestMethod, TestCategory("unit")]
        public void AsCurrencyString_ShouldBeExpectedFormatForNegativeNumber()
        {
            //Arrange
            CurrencyField subject = new TestCurrencyField(new FakeRecord("-0000102"), 0, 0);

            //Act
            string actual = subject.AsCurrencyString();

            //Assert
            actual.Should().Be("($1.02)");
        }

        [TestMethod, TestCategory("unit")]
        public void AsSystemType_ShouldBeExpectedValue()
        {
            //Arrange
            CurrencyField subject = new TestCurrencyField(new FakeRecord("-0000102"), 0, 0);

            //Act
            decimal actual = subject;

            //Assert
            actual.Should().Be(-1.02m);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldThrowExceptionIfNotNumeric()
        {
            //Arrange
            CurrencyField subject = new TestCurrencyField(new FakeRecord("A0000102"), 0, 0);

            //Act
            Action action = () => subject.AsSystemType();

            //Assert
            action.Should().Throw<InvalidCurrencyFieldException>();
        }
        
        private sealed class TestCurrencyField : CurrencyField
        {
            public TestCurrencyField(IRecord record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased)
            {}
        }
    }
}