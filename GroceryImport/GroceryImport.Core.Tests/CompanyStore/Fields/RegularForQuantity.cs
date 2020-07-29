using GroceryImport.Core.Tests.BaseTypes;

namespace GroceryImport.Core.Tests.CompanyStore.Fields
{
    internal sealed class RegularForQuantity : NumberField
    {
        private const int StartIndexOnesBased = 106;
        private const int EndIndexOnesBased = 113;

        public RegularForQuantity(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}