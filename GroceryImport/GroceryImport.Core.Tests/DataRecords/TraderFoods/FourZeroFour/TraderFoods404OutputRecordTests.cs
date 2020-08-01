using FluentAssertions;
using GroceryImport.Core.DataRecords.ProductRecords;
using GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour
{
    [TestClass]
    public class TraderFoods404OutputRecordTests
    {
        [TestMethod, TestCategory("unit")]
        public void CompanyId_ShouldBeExpectedValue()
        {
            //Arrange
            TraderFoods404OutputRecord subject = new TraderFoods404OutputRecord(null);

            //Act
            string actual = subject.CompanyId();

            //Assert
            actual.Should().Be("TradeFoodsUniqueId");
        }

        [TestMethod, TestCategory("unit")]
        public void ProductId_ShouldReturnParsedValue()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            int actual = subject.ProductId();

            //Assert
            actual.Should().Be(80000001);
        }

        [TestMethod, TestCategory("unit")]
        public void ProductDescription_ShouldReturnParsedValue()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            string actual = subject.ProductDescription();

            //Assert
            actual.Should().Be("Kimchi-flavored white rice");
        }

        [TestMethod, TestCategory("unit")]
        public void ProductSize_ShouldReturnParsedValue()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            string actual = subject.ProductSize();

            //Assert
            actual.Should().Be("18oz");
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalCalculatorPrice_ShouldReturnSplitWhenSplit()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00005678 00001472 00003698 00000002 00000004 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            decimal actual = subject.PromotionalCalculatorPrice();

            //Assert
            actual.Should().Be(36.98m/4);
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalDisplayPrice_ShouldReturnSplitWhenSplit()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00005678 00001472 00003698 00000002 00000004 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            string actual = subject.PromotionalDisplayPrice();

            //Assert
            actual.Should().Be("4 for $36.98");
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalCalculatorPrice_ShouldReturnNonSplitWhenNoSplit()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00005678 00001472 00000000 00000002 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            decimal actual = subject.PromotionalCalculatorPrice();

            //Assert
            actual.Should().Be(56.78m);
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalDisplayPrice_ShouldReturnNonSplitWhenNoSplit()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00005678 00001472 00000000 00000002 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            string actual = subject.PromotionalDisplayPrice();

            //Assert
            actual.Should().Be("$56.78");
        }

        [TestMethod, TestCategory("unit")]
        public void RegularCalculatorPrice_ShouldReturnSplitWhenSplit()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00005678 00001472 00003698 00000002 00000004 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            decimal actual = subject.RegularCalculatorPrice();

            //Assert
            actual.Should().Be(14.72m / 2);
        }

        [TestMethod, TestCategory("unit")]
        public void RegularDisplayPrice_ShouldReturnSplitWhenSplit()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00005678 00001472 00003698 00000002 00000004 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            string actual = subject.RegularDisplayPrice();

            //Assert
            actual.Should().Be("2 for $14.72");
        }

        [TestMethod, TestCategory("unit")]
        public void RegularCalculatorPrice_ShouldReturnNonSplitWhenNoSplit()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000000 00001472 00000000 00000000 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            decimal actual = subject.RegularCalculatorPrice();

            //Assert
            actual.Should().Be(12.34m);
        }

        [TestMethod, TestCategory("unit")]
        public void RegularDisplayPrice_ShouldReturnNonSplitWhenNoSplit()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000000 00001472 00000000 00000000 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            string actual = subject.RegularDisplayPrice();

            //Assert
            actual.Should().Be("$12.34");
        }

        [TestMethod, TestCategory("unit")]
        public void StoreId_ShouldReturnExpectedValue()
        {
            //Arrange
            ProductRecord subject = new TraderFoods404OutputRecord(null);

            //Act
            string actual = subject.StoreId();

            //Assert
            actual.Should().Be("TradeFoodsUniqueId:404");
        }

        [TestMethod, TestCategory("unit")]
        public void TaxRate_ShouldBe0GivenNonTaxFlag()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000000 00001472 00000000 00000000 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            double actual = subject.TaxRate();

            //Assert
            actual.Should().Be(0d);
        }

        [TestMethod, TestCategory("unit")]
        public void TaxRate_ShouldBe7775GivenTaxFlag()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000000 00001472 00000000 00000000 00000000 NNNNYNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            double actual = subject.TaxRate();

            //Assert
            actual.Should().Be(0.07775d);
        }

        [TestMethod, TestCategory("unit")]
        public void UnitOfMeasure_ShouldBeEachGivenNotPerWeight()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000000 00001472 00000000 00000000 00000000 NNNNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            string actual = subject.UnitOfMeasure();

            //Assert
            actual.Should().Be("Each");
        }

        [TestMethod, TestCategory("unit")]
        public void UnitOfMeasure_ShouldBePoundGivenPerWeight()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000000 00001472 00000000 00000000 00000000 NNYNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            string actual = subject.UnitOfMeasure();

            //Assert
            actual.Should().Be("Pound");
        }

        [TestMethod, TestCategory("unit")]
        public void IsPromotional_ShouldBeTrueGivenPromotionalPricing()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000100 00001472 00000000 00000000 00000000 NNYNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            bool actual = subject.IsPromotional();

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void IsPromotional_ShouldBeFalseGivenNoPromotionalPricing()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000000 00001472 00000000 00000000 00000000 NNYNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            bool actual = subject.IsPromotional();

            //Assert
            actual.Should().BeFalse();
        }
        [TestMethod, TestCategory("unit")]
        public void IsRegular_ShouldBeTrueGivenRegularPricing()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00001234 00000100 00001472 00000000 00000000 00000000 NNYNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            bool actual = subject.IsRegular();

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void IsRegular_ShouldBeFalseGivenNoRegularPricing()
        {
            //Arrange
            string lazy = "80000001 Kimchi-flavored white rice                                  00000000 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN      18oz";
            ProductRecord subject = new TraderFoods404OutputRecord(lazy);

            //Act
            bool actual = subject.IsRegular();

            //Assert
            actual.Should().BeFalse();
        }
    }
}