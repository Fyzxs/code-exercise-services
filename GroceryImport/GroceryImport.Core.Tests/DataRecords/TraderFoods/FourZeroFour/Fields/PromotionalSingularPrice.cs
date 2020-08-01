using GroceryImport.Core.Tests.DataRecords.BaseTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.Fields
{
    internal sealed class PromotionalSingularPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 79;
        private const int EndIndexOnesBased = 86;

        public PromotionalSingularPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
    internal sealed class RegularSingularPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 70;
        private const int EndIndexOnesBased = 77;

        public RegularSingularPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}