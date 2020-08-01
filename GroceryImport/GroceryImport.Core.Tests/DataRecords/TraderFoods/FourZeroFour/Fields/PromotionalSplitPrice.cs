using GroceryImport.Core.Tests.DataRecords.BaseTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.Fields
{
    internal sealed class PromotionalSplitPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 97;
        private const int EndIndexOnesBased = 104;

        public PromotionalSplitPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}