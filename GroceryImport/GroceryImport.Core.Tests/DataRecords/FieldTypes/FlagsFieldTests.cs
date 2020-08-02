using FluentAssertions;
using GroceryImport.Core.DataRecords.FieldTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    [TestClass]
    public class FlagsFieldTests
    {
        [TestMethod, TestCategory("unit")]
        public void METHOD_NAME_ShouldTEST()
        {
            //Arrange
            FlagsField subject = new TestFlagsField(new Record("IgnoreMeYYYYYAndAgain"), 9, 13);

            //Act
            string actual = subject;

            //Assert
            actual.Should().Be("YYYYY");
        }

        private sealed class TestFlagsField : FlagsField
        {
            public TestFlagsField(IRecord record, int startIndexOnesBased, int inclusiveEndIndexOnesBased) : base(record, startIndexOnesBased, inclusiveEndIndexOnesBased)
            {
            }
        }
    }
}