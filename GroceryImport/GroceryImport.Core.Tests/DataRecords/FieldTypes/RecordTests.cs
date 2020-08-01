using FluentAssertions;
using GroceryImport.Core.DataRecords.FieldTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    [TestClass]
    public class RecordTests
    {
        [TestMethod, TestCategory("unit")]
        public void FieldStringValue_ShouldReturnStringOfIndex()
        {
            //Arrange
            Record subject = new Record("this is my record string!");

            //Act
            string actual = subject.FieldStringValue(5, 9);

            //Assert
            actual.Should().Be(" is m");
        }
    }
}