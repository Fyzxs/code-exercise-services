using GroceryImport.Core.Tests.DataRecords.BaseTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.Fields
{
    internal sealed class ProductId : NumberField
    {
        private const int StartIndexOnesBased = 1;
        private const int EndIndexOnesBased = 8;

        public ProductId(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}