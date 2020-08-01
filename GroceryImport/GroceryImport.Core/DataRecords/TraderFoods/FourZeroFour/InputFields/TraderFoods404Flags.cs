using GroceryImport.Core.Tests.DataRecords.FieldTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404Flags : FlagsField
    {
        private const int StartIndexOnesBased = 124;
        private const int EndIndexOnesBased = 132;

        public TraderFoods404Flags(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }

        public Flag PerWeight() => new TraderFoods404PerWeightFlag(Value());

        public Flag Taxable() => new TraderFoods404TaxableFlag(Value());

    }
    internal sealed class TraderFoods404TaxableFlag : Flag
    {
        private const int FlagIndex = 5;

        public TraderFoods404TaxableFlag(string value) : base(value, FlagIndex)
        { }
    }

    internal sealed class TraderFoods404PerWeightFlag : Flag
    {
        private const int FlagIndex = 3;

        public TraderFoods404PerWeightFlag(string value) : base(value, FlagIndex)
        { }
    }
}