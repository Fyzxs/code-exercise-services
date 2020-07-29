using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using FluentAssertions;
using FluentAssertions.Common;
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
            CompanyStoreProductRecord companyStoreProductRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = companyStoreProductRecord.ProductDescription();

            //Assert
            actual.Should().Be("Generic Soda 12-pack");
        }

        [TestMethod, TestCategory("unit")]
        public void ProductIdShouldBeExpected()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreProductRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            int actual = companyStoreProductRecord.ProductId();

            //Assert
            actual.Should().Be(14963801);
        }

        [TestMethod, TestCategory("unit")]
        public void PromotionalSingularPriceShouldBeExpected()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreProductRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            decimal actual = companyStoreProductRecord.PromotionalSingularPrice();

            //Assert
            actual.Should().Be(5.49m);
        }
        [TestMethod, TestCategory("unit")]
        public void PromotionalSingularPriceShouldHandleNegatives()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreProductRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 -0000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            decimal actual = companyStoreProductRecord.PromotionalSingularPrice();

            //Assert
            actual.Should().Be(-5.49m);
        }

        [TestMethod, TestCategory("unit")]
        public void PerWeightShouldBeFalse()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreProductRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            bool subject = companyStoreProductRecord.IsPerWeight();

            //Assert
            subject.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void TaxableShouldBeTrue()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreProductRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            bool subject = companyStoreProductRecord.IsTaxable();

            //Assert
            subject.Should().BeTrue();
        }
    }
    public class CompanyStoreProductRecord
    {
        private readonly Record _record;

        public CompanyStoreProductRecord(string record) : this(new Record(record)) { }

        public CompanyStoreProductRecord(Record record) => _record = record;

        public NumberField ProductId() => new CompanyStoreProductId(_record);
        public StringField ProductDescription() => new CompanyStoreProductDescription(_record);
        public CurrencyField PromotionalSingularPrice() => new CompanyStorePromotionalSingularPrice(_record);
        private CompanyStoreFlags Flags() => new CompanyStoreFlags(_record);

        public Flag IsPerWeight() => Flags().PerWeight();
        public Flag IsTaxable() => Flags().Taxable();
    }

    public sealed class CompanyStoreProductId : NumberField
    {
        private const int StartIndexOnesBased = 1;
        private const int EndIndexOnesBased = 8;

        public CompanyStoreProductId(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }

    public sealed class CompanyStoreProductDescription : StringField
    {
        private const int StartIndexOnesBased = 10;
        private const int EndIndexOnesBased = 68;

        public CompanyStoreProductDescription(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }

    public sealed class CompanyStorePromotionalSingularPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 79;
        private const int EndIndexOnesBased = 86;

        public CompanyStorePromotionalSingularPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }

    public sealed class CompanyStoreFlags : FlagsField
    {
        private int PerWeightIndex = 3;
        private int TaxableIndex = 5;
        private const int StartIndexOnesBased = 124;
        private const int EndIndexOnesBased = 132;

        public CompanyStoreFlags(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
        public Flag PerWeight() => new CompanyStoreFlagPerWeight(Value());

        public Flag Taxable() => new CompanyStoreFlagTaxable(Value());
    }

    public sealed class CompanyStoreFlagPerWeight : Flag
    {
        public CompanyStoreFlagPerWeight(string value) : base(value, 3)
        {}
    }
    public sealed class CompanyStoreFlagTaxable : Flag
    {
        public CompanyStoreFlagTaxable(string value) : base(value, 5)
        {}
    }


    public abstract class FlagsField : Field<string>
    {
        protected FlagsField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override string AsSystemType() => Value();
    }

    public abstract class Flag : ToSystem<bool>
    {
        private const string TrueValue = "Y";
        private readonly string _value;
        private readonly int _flagNumber;

        protected Flag(string value, int flagNumber)
        {
            _value = value;
            _flagNumber = flagNumber;
        }
        public override bool AsSystemType() => _value.Substring(_flagNumber - 1, 1) == TrueValue;
    }

    public abstract class CurrencyField : Field<decimal>
    {
        //TODO: Currency requires a money object - I'm being a bit forgiving here. We'll see how long I stay that way.

        protected CurrencyField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override decimal AsSystemType()
        {
            string substring = Value();
            if (!int.TryParse(substring, out int result)) return decimal.MinValue;

            return result / 100m;
        }
    }

    public abstract class StringField : Field<string>
    {
        public StringField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override string AsSystemType() => Value().Trim();
    }

    public class NumberField : Field<int>
    {
        public NumberField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override int AsSystemType()
        {
            string substring = Value();
            if (int.TryParse(substring, out int result)) return result;
            return int.MinValue;//TODO: Find a good "Broken"?
        }
    }

    public abstract class Field<T> : ToSystem<T>
    {
        private readonly Record _record;
        private readonly int _startIndexOnesBased;
        private readonly int _endIndexOnesBased;

        protected Field(Record record, int startIndexOnesBased, int endIndexOnesBased)
        {
            _record = record;
            _startIndexOnesBased = startIndexOnesBased;
            _endIndexOnesBased = endIndexOnesBased;
        }

        protected string Value() => _record.FieldStringValue(_startIndexOnesBased, _endIndexOnesBased);
    }

    public sealed class Record
    {
        private readonly string _record;

        public Record(string record) => _record = record;

        public string FieldStringValue(int startIndexOnesBased, int endIndexOnesBased) => _record.Substring(StartIndex(startIndexOnesBased), EndIndex(startIndexOnesBased, endIndexOnesBased));

        private static int EndIndex(int startIndexOnesBased, int endIndexOnesBased) => endIndexOnesBased - StartIndex(startIndexOnesBased);

        private static int StartIndex(int startIndexOnesBased) => startIndexOnesBased - 1;
    }

    public interface IValidate
    {
        bool IsValid();
    }
}
