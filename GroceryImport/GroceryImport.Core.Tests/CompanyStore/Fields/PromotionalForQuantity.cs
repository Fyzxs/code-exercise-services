using GroceryImport.Core.Tests.BaseTypes;

namespace GroceryImport.Core.Tests.CompanyStore.Fields
{
    internal sealed class PromotionalForQuantity : NumberField
    {
        private const int StartIndexOnesBased = 115;
        private const int EndIndexOnesBased = 122;

        public PromotionalForQuantity(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}