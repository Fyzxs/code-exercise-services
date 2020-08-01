using FluentAssertions;
using GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour
{
    [TestClass]
    public class TraderFoods404InputRecordTests
    {
        //string record = "50133333 Fuji Apples (Organic)                                       00000000 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
        
        [TestMethod, TestCategory("unit")]
        public void HasPromotionalPricing_ShouldReturnTrueForNonZeroSingular()
        {
            //Arrange
            string record = "50133333 Fuji Apples (Organic)                                       00000000 00000111 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
            TraderFoods404InputRecord subject = new TraderFoods404InputRecord(record);

            //Act
            bool actual = subject.HasPromotionalPricing();

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void HasPromotionalPricing_ShouldReturnTrueForNonZeroSplit()
        {
            //Arrange
            string record = "50133333 Fuji Apples (Organic)                                       00000000 00000000 00000000 00000100 00000000 00000000 NNYNNNNNN        lb";
            TraderFoods404InputRecord subject = new TraderFoods404InputRecord(record);

            //Act
            bool actual = subject.HasPromotionalPricing();

            //Assert
            actual.Should().BeTrue();
        }
        
        [TestMethod, TestCategory("unit")]
        public void HasRegularPricing_ShouldReturnTrueForNonZeroSingular()
        {
            //Arrange
            string record = "50133333 Fuji Apples (Organic)                                       00000100 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
            TraderFoods404InputRecord subject = new TraderFoods404InputRecord(record);

            //Act
            bool actual = subject.HasRegularPricing();

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void HasRegularPricing_ShouldReturnTrueForNonZeroSplit()
        {
            //Arrange
            string record = "50133333 Fuji Apples (Organic)                                       00000000 00000000 00001000 00000000 00000000 00000000 NNYNNNNNN        lb";
            TraderFoods404InputRecord subject = new TraderFoods404InputRecord(record);

            //Act
            bool actual = subject.HasRegularPricing();

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void IsRegularSplitPrice_ShouldReturnFalseRegularPriceAndNoSplit()
        {
            //Arrange
            string record = "50133333 Fuji Apples (Organic)                                       00000100 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
            TraderFoods404InputRecord subject = new TraderFoods404InputRecord(record);

            //Act
            bool actual = subject.IsRegularSplitPrice();

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void IsRegularSplitPrice_ShouldReturnFalseNoRegularSplitPriceAndWithRegularForX()
        {
            //Note: This test is for an invalid situation, but verifying the system behaves correct
            //Arrange
            string record = "50133333 Fuji Apples (Organic)                                       00000100 00000000 00000000 00000000 00000002 00000000 NNYNNNNNN        lb";
            TraderFoods404InputRecord subject = new TraderFoods404InputRecord(record);

            //Act
            bool actual = subject.IsRegularSplitPrice();

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void IsRegularSplitPrice_ShouldReturnFalseNoRegularSplitPriceAndRegularSplit()
        {
            //Note: This test is for an invalid situation, but verifying the system behaves correct
            //Arrange
            string record = "50133333 Fuji Apples (Organic)                                       00000100 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
            TraderFoods404InputRecord subject = new TraderFoods404InputRecord(record);

            //Act
            bool actual = subject.IsRegularSplitPrice();

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void IsRegularSplitPrice_ShouldReturnTrueForRegularPriceAndSplitItems()
        {
            //Note: This test is for an invalid situation, but verifying the system behaves correct
            //Arrange
            string record = "50133333 Fuji Apples (Organic)                                       00000100 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
            TraderFoods404InputRecord subject = new TraderFoods404InputRecord(record);

            //Act
            bool actual = subject.IsRegularSplitPrice();

            //Assert
            actual.Should().BeFalse();
        }
    }
}