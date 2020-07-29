using GroceryImport.Core.Tests.BaseTypes;

namespace GroceryImport.Core.Tests.CompanyStore.Fields
{
    internal sealed class ProductDescription : StringField
    {
        private const int StartIndexOnesBased = 10;
        private const int EndIndexOnesBased = 68;

        public ProductDescription(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}