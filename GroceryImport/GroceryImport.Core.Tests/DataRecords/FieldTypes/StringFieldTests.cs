using FluentAssertions;
using GroceryImport.Core.DataRecords.FieldTypes;
using GroceryImport.Core.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    [TestClass]
    public class StringFieldTests
    {
        [TestMethod, TestCategory("unit")]
        public void AsSystemType_ShouldReturnTrimmedValue()
        {
            //Arrange
            StringField subject = new TestStringField(new FakeRecord(" \t\r\nLookAtAllThatWhiteSpace\n\r\t "), 0, 0);

            //Act
            string actual = subject;

            //Assert
            actual.Should().Be("LookAtAllThatWhiteSpace");
        }

        private sealed class TestStringField : StringField
        {
            public TestStringField(IRecord record, int startIndexOnesBased, int inclusiveEndIndexOnesBased) : base(record, startIndexOnesBased, inclusiveEndIndexOnesBased)
            {
            }
        }
    }
}