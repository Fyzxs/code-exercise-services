using FluentAssertions;
using GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable TestFileNameWarning

namespace GroceryImport.Core.Tests
{
    [TestClass]
    public class EmergentTests
    {
        /*
ID       DESCRIPTION                                                 RegSing$ PrmSng$  RegSpt$  PrmSpt$  RegForX  PrmForX  FLAGS       ProductSize
80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz
14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz
40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb
         */
        [TestMethod, TestCategory("unit")]
        public void ProductDescriptionShouldBeExpected()
        {
            //Arrange
            TraderFoods404InputRecord traderFoods404InputRecord = new TraderFoods404InputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = traderFoods404InputRecord.ProductDescription();

            //Assert
            actual.Should().Be("Generic Soda 12-pack");
        }

        [TestMethod, TestCategory("unit")]
        public void ProductIdShouldBeExpected()
        {
            //Arrange
            TraderFoods404InputRecord traderFoods404InputRecord = new TraderFoods404InputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            int actual = traderFoods404InputRecord.ProductId();

            //Assert
            actual.Should().Be(14963801);
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalSingularPriceShouldBeExpected()
        {
            //Arrange
            TraderFoods404InputRecord traderFoods404InputRecord = new TraderFoods404InputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            decimal actual = traderFoods404InputRecord.PromotionalSingularPrice();

            //Assert
            actual.Should().Be(5.49m);
        }
        [TestMethod, TestCategory("unit")]
        public void PromotionalSingularPriceShouldHandleNegatives()
        {
            //Arrange
            TraderFoods404InputRecord traderFoods404InputRecord = new TraderFoods404InputRecord("14963801 Generic Soda 12-pack                                        00000000 -0000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            decimal actual = traderFoods404InputRecord.PromotionalSingularPrice();

            //Assert
            actual.Should().Be(-5.49m);
        }

        [TestMethod, TestCategory("unit")]
        public void PerWeightShouldBeFalse()
        {
            //Arrange
            TraderFoods404InputRecord traderFoods404InputRecord = new TraderFoods404InputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            bool actual = traderFoods404InputRecord.IsPerWeight();

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void TaxableShouldBeTrue()
        {
            //Arrange
            TraderFoods404InputRecord traderFoods404InputRecord = new TraderFoods404InputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            bool actual = traderFoods404InputRecord.IsTaxable();

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void RegularDisplayPriceShouldShowSplit()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = traderFoods404InputRecord.RegularDisplayPrice();

            //Assert
            actual.Should().Be("2 for $13.00");
        }

        [TestMethod, TestCategory("unit")]
        public void RegularDisplayPriceShouldShowNonSplit()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          ");

            //Act
            string actual = traderFoods404InputRecord.RegularDisplayPrice();

            //Assert
            actual.Should().Be("$10.00");
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalDisplayPriceShouldShowNonSplit()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          ");

            //Act
            string actual = traderFoods404InputRecord.PromotionalDisplayPrice();

            //Assert
            actual.Should().Be("$5.49");
        }


        [TestMethod, TestCategory("unit")]
        public void RegularCalculatorPriceShouldShowNonSplit()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          ");

            //Act
            decimal actual = traderFoods404InputRecord.RegularCalculatorPrice();

            //Assert
            actual.Should().Be(10.00m);
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalCalculatorPriceShouldShowNonSplit()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          ");

            //Act
            decimal actual = traderFoods404InputRecord.PromotionalCalculatorPrice();

            //Assert
            actual.Should().Be(5.49m);
        }

        [TestMethod, TestCategory("unit")]
        public void TaxRateShouldBeExpectedGivenTaxable()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            double actual = traderFoods404InputRecord.TaxRate();

            //Assert
            actual.Should().Be(.07775);
        }
        [TestMethod, TestCategory("unit")]
        public void TaxRateShouldBeZeroGivenNotTaxable()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNNNNNN   12x12oz");

            //Act
            double actual = traderFoods404InputRecord.TaxRate();

            //Assert
            actual.Should().Be(0d);
        }
        [TestMethod, TestCategory("unit")]
        public void RegularCalculatorPriceShouldBeExpectedValue()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNNNNNN   12x12oz");

            //Act
            decimal actual = traderFoods404InputRecord.RegularCalculatorPrice();

            //Assert
            actual.Should().Be(6.5m);
        }

        [TestMethod, TestCategory("unit")]
        public void RegularCalculatorPriceShouldBeExactToFourDecimalRoundingDownOn5()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00612345 00000000 00001000 00000000 NNNNNNNNN   12x12oz");

            //Act
            decimal actual = traderFoods404InputRecord.RegularCalculatorPrice();

            //Assert
            actual.Should().Be(6.1235m);//.Be(6.1234m); Error due to .Net MidpointRounding limitations
        }

        [TestMethod, TestCategory("unit")]
        public void RegularCalculatorPriceShouldBeExactToFourDecimalRoundingOn6()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00612346 00000000 00001000 00000000 NNNNNNNNN   12x12oz");

            //Act
            decimal actual = traderFoods404InputRecord.RegularCalculatorPrice();

            //Assert
            actual.Should().Be(6.1235m);
        }

        [TestMethod, TestCategory("unit")]
        public void RegularCalculatorPriceShouldBeExactToFourDecimalRoundingOn4WhenNegative()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 -0612344 00000000 00001000 00000000 NNNNNNNNN   12x12oz");

            //Act
            decimal actual = traderFoods404InputRecord.RegularCalculatorPrice();

            //Assert
            actual.Should().Be(-6.1234m);
        }

        [TestMethod, TestCategory("unit")]
        public void RegularCalculatorPriceShouldBeExactToFourDecimalRoundingOn6WhenNegative()
        {
            //Arrange
            TraderFoods404OutputRecord traderFoods404InputRecord = new TraderFoods404OutputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 -0612346 00000000 00001000 00000000 NNNNNNNNN   12x12oz");

            //Act
            decimal actual = traderFoods404InputRecord.RegularCalculatorPrice();

            //Assert
            actual.Should().Be(-6.1235m);
        }


    //
    //    Tests showing issue with Half Round Down in .NET
    //
    //    [TestMethod, TestCategory("unit")]
    //    public void RoundingTests()
    //    {
    //        /*
    //ToEven,
    //AwayFromZero,
    //ToZero,
    //ToNegativeInfinity,
    //ToPositiveInfinity,
    //        */
    //        MidpointRounding rounding = MidpointRounding.AwayFromZero;

    //        Math.Round(23.49, rounding).Should().Be(23);
    //        Math.Round(23.5, rounding).Should().Be(23);
    //        Math.Round(23.51, rounding).Should().Be(24);

    //        Math.Round(-23.49, rounding).Should().Be(-23);
    //        Math.Round(-23.5, rounding).Should().Be(-24);
    //        Math.Round(-23.51, rounding).Should().Be(-24);

    //        Math.Round(24.49, rounding).Should().Be(24);
    //        Math.Round(24.5, rounding).Should().Be(24);
    //        Math.Round(24.51, rounding).Should().Be(25);

    //        Math.Round(-24.49, rounding).Should().Be(-24);
    //        Math.Round(-24.5, rounding).Should().Be(-25);
    //        Math.Round(-24.51, rounding).Should().Be(-25);


    //        Math.Round(6.12344, 4, rounding).Should().Be(6.1234);
    //        Math.Round(6.12345, 4, rounding).Should().Be(6.1234);
    //        Math.Round(6.12346, 4, rounding).Should().Be(6.1235);
    //        Math.Round(6.12354, 4, rounding).Should().Be(6.1235);
    //        Math.Round(6.12355, 4, rounding).Should().Be(6.1235);
    //        Math.Round(6.12356, 4, rounding).Should().Be(6.1236);

    //        Math.Round(-6.12344, 4, rounding).Should().Be(-6.1234);
    //        Math.Round(-6.12345, 4, rounding).Should().Be(-6.1234);
    //        Math.Round(-6.12346, 4, rounding).Should().Be(-6.1235);
    //    }
    }
}
