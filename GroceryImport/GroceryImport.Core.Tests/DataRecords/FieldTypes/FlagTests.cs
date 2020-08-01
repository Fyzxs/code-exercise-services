using FluentAssertions;
using GroceryImport.Core.DataRecords.FieldTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    [TestClass]
    public class FlagTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueWhenY()
        {
            //Arrange
            Flag subject = new TestFlag("123Y567", 4);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseWhenNotY()
        {
            //Arrange
            Flag subject = new TestFlag("123A567", 4);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
        private sealed class TestFlag : Flag
        {
            public TestFlag(string value, int flagNumber) : base(value, flagNumber)
            {
            }
        }
    }
}