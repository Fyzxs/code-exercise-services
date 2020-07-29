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
        public void FlagsShouldBeExpected()
        {
            //Arrange
            CompanyStoreProductRecord companyStoreProductRecord = new CompanyStoreProductRecord("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");
            FlagsField subject = companyStoreProductRecord.Flags();

            //Act

            //Assert
            ((bool) subject.GetFlag(1)).Should().BeFalse();
            ((bool) subject.GetFlag(2)).Should().BeFalse();
            ((bool) subject.GetFlag(3)).Should().BeFalse();
            ((bool) subject.GetFlag(4)).Should().BeFalse();
            ((bool) subject.GetFlag(5)).Should().BeTrue();
        }
    }

    public class CompanyStoreProductRecord
    {
        private readonly Record _record;

        public CompanyStoreProductRecord(string record) : this(new Record(record)) { }

        public CompanyStoreProductRecord(Record record) => _record = record;

        public NumberField ProductId() => new NumberField(_record, 1, 8);
        public StringField ProductDescription() => new StringField(_record, 10, 68);
        public CurrencyField PromotionalSingularPrice() => new CurrencyField(_record, 79, 86);

        public FlagsField Flags() => new FlagsField(_record, 124, 132);
    }

    public class FlagsField : Field<string>
    {
        public FlagsField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public Flag GetFlag(int flagNumber) => new Flag(Value(), flagNumber);

        public override string AsSystemType() => Value();
    }

    public class Flag : ToSystem<bool>
    {
        private const string TrueValue = "Y";
        private readonly string _value;
        private readonly int _flagNumber;

        public Flag(string value, int flagNumber)
        {
            _value = value;
            _flagNumber = flagNumber;
        }
        public override bool AsSystemType() => _value.Substring(_flagNumber - 1, 1) == TrueValue;
    }

    public sealed class CurrencyField : Field<decimal>
    {
        //TODO: Currency requires a money object - I'm being a bit forgiving here. We'll see how long I stay that way.

        public CurrencyField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override decimal AsSystemType()
        {
            string substring = Value();
            if (!int.TryParse(substring, out int result)) return decimal.MinValue;

            return result / 100m;
        }
    }

    public sealed class StringField : Field<string>
    {
        public StringField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override string AsSystemType() => Value().Trim();
    }

    public sealed class NumberField : Field<int>
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
