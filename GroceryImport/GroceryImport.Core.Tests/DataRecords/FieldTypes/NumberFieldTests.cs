using System;
using FluentAssertions;
using GroceryImport.Core.DataRecords.FieldTypes;
using GroceryImport.Core.Exceptions;
using GroceryImport.Core.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    [TestClass]
    public class NumberFieldTests
    {
        [TestMethod, TestCategory("unit")]
        public void AsSystemType_ShouldProvideExpectedValue()
        {
            //Arrange
            NumberField subject = new TestNumberField(new FakeRecord("00000001"),0, 0 );

            //Act
            int actual = subject;

            //Assert
            actual.Should().Be(1);
        }


        [TestMethod, TestCategory("unit")]
        public void ShouldThrowExceptionIfNotNumeric()
        {
            //Arrange
            NumberField subject = new TestNumberField(new FakeRecord("A0000102"), 0, 0);

            //Act
            Action action = () => subject.AsSystemType();

            //Assert
            action.Should().Throw<InvalidNumberFieldException>();
        }

        private sealed class TestNumberField:NumberField
        {
            public TestNumberField(IRecord record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased)
            {
            }
        }
    }
}