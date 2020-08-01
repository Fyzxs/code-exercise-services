using GroceryImport.Core.Tests.DataRecords.BaseTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.Fields
{
    internal sealed class RegularSplitPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 88;
        private const int EndIndexOnesBased = 95;

        public RegularSplitPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}