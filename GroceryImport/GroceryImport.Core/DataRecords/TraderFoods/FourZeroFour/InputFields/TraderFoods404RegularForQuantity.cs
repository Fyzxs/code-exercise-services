using GroceryImport.Core.Tests.DataRecords.FieldTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404RegularForQuantity : NumberField
    {
        private const int StartIndexOnesBased = 106;
        private const int EndIndexOnesBased = 113;

        public TraderFoods404RegularForQuantity(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}