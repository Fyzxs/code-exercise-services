using GroceryImport.Core.Tests.BaseTypes;

namespace GroceryImport.Core.Tests.CompanyStore.Fields
{
    internal sealed class PromotionalSplitPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 97;
        private const int EndIndexOnesBased = 104;

        public PromotionalSplitPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}