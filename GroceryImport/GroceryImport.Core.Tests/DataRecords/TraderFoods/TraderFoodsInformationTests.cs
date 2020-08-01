using FluentAssertions;
using GroceryImport.Core.DataRecords.TraderFoods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods
{
    [TestClass]
    public class TraderFoodsInformationTests
    {
        [TestMethod, TestCategory("unit")]
        public void CompanyId_ShouldBeExpectedValue()
        {
            //Arrange
            IChainInformation subject = new TraderFoodsInformation();

            //Act
            string actual = subject.CompanyId();

            //Assert
            actual.Should().Be("TradeFoodsUniqueId");
        }
    }
}