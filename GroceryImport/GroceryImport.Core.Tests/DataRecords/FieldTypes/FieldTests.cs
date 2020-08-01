using FluentAssertions;
using GroceryImport.Core.DataRecords.FieldTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod, TestCategory("unit")]
        public void Value_ShouldReturnSubstringSpecified()
        {
            //Arrange
            Field<string> subject = new TestField(new Record("ThisIsAString"), 5,6);

            //Act
            string actual = subject;

            //Assert
            actual.Should().Be("Is");
        }

        private sealed class TestField : Field<string>
        {
            public TestField(IRecord record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased)
            {
            }

            public override string AsSystemType() => Value();
        }
    }
}