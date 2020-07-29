using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using FluentAssertions;
using FluentAssertions.Common;
using GroceryImport.Core.Tests.CompanyStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            CompanyStoreInputRecord companyStoreInputRecord = new CompanyStoreInputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = companyStoreInputRecord.ProductDescription();

            //Assert
            actual.Should().Be("Generic Soda 12-pack");
        }

        [TestMethod, TestCategory("unit")]
        public void ProductIdShouldBeExpected()
        {
            //Arrange
            CompanyStoreInputRecord companyStoreInputRecord = new CompanyStoreInputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            int actual = companyStoreInputRecord.ProductId();

            //Assert
            actual.Should().Be(14963801);
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalSingularPriceShouldBeExpected()
        {
            //Arrange
            CompanyStoreInputRecord companyStoreInputRecord = new CompanyStoreInputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            decimal actual = companyStoreInputRecord.PromotionalSingularPrice();

            //Assert
            actual.Should().Be(5.49m);
        }
        [TestMethod, TestCategory("unit")]
        public void PromotionalSingularPriceShouldHandleNegatives()
        {
            //Arrange
            CompanyStoreInputRecord companyStoreInputRecord = new CompanyStoreInputRecord("14963801 Generic Soda 12-pack                                        00000000 -0000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            decimal actual = companyStoreInputRecord.PromotionalSingularPrice();

            //Assert
            actual.Should().Be(-5.49m);
        }

        [TestMethod, TestCategory("unit")]
        public void PerWeightShouldBeFalse()
        {
            //Arrange
            CompanyStoreInputRecord companyStoreInputRecord = new CompanyStoreInputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            bool actual = companyStoreInputRecord.IsPerWeight();

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void TaxableShouldBeTrue()
        {
            //Arrange
            CompanyStoreInputRecord companyStoreInputRecord = new CompanyStoreInputRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            bool actual = companyStoreInputRecord.IsTaxable();

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void RegularDisplayPriceShouldShowSplit()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreInputRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = companyStoreInputRecord.RegularDisplayPrice();

            //Assert
            actual.Should().Be("2 for $13.00");
        }
        [TestMethod, TestCategory("unit")]
        public void TaxRateShouldBeExpectedGivenTaxable()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreInputRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            double actual = companyStoreInputRecord.TaxRate();

            //Assert
            actual.Should().Be(.07775);
        }
        [TestMethod, TestCategory("unit")]
        public void TaxRateShouldBeZeroGivenNotTaxable()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreInputRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNNNNNN   12x12oz");

            //Act
            double actual = companyStoreInputRecord.TaxRate();

            //Assert
            actual.Should().Be(0d);
        }
    }
}
