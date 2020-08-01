using GroceryImport.Core.Tests.DataRecords.BaseTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.Fields
{
    internal sealed class Flags : FlagsField
    {
        private const int StartIndexOnesBased = 124;
        private const int EndIndexOnesBased = 132;

        public Flags(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }

        public Flag PerWeight() => new PerWeightFlag(Value());

        public Flag Taxable() => new TaxableFlag(Value());

    }
    internal sealed class TaxableFlag : Flag
    {
        private const int FlagIndex = 5;

        public TaxableFlag(string value) : base(value, FlagIndex)
        { }
    }

    internal sealed class PerWeightFlag : Flag
    {
        private const int FlagIndex = 3;

        public PerWeightFlag(string value) : base(value, FlagIndex)
        { }
    }
}