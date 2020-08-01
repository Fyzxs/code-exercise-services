using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404RegularForQuantity : NumberField
    {
        private const int StartIndexOnesBased = 106;
        private const int EndIndexOnesBased = 113;

        public TraderFoods404RegularForQuantity(IRecord record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}