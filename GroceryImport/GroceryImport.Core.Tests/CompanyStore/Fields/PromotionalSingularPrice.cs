using GroceryImport.Core.Tests.BaseTypes;

namespace GroceryImport.Core.Tests.CompanyStore.Fields
{
    internal sealed class PromotionalSingularPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 79;
        private const int EndIndexOnesBased = 86;

        public PromotionalSingularPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}