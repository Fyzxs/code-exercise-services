using GroceryImport.Core.Tests.DataRecords.BaseTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.Fields
{
    internal sealed class ProductDescription : StringField
    {
        private const int StartIndexOnesBased = 10;
        private const int EndIndexOnesBased = 68;

        public ProductDescription(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}