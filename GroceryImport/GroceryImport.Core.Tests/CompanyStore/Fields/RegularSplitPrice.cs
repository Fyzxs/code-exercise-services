using GroceryImport.Core.Tests.BaseTypes;

namespace GroceryImport.Core.Tests.CompanyStore.Fields
{
    internal sealed class RegularSplitPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 88;
        private const int EndIndexOnesBased = 95;

        public RegularSplitPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}