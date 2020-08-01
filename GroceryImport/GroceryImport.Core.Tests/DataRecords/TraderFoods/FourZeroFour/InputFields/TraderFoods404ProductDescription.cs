using GroceryImport.Core.Tests.DataRecords.FieldTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404ProductDescription : StringField
    {
        private const int StartIndexOnesBased = 10;
        private const int EndIndexOnesBased = 68;

        public TraderFoods404ProductDescription(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}