using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404ProductId : NumberField
    {
        private const int StartIndexOnesBased = 1;
        private const int InclusiveEndIndexOnesBased = 8;

        public TraderFoods404ProductId(IRecord record) : base(record, StartIndexOnesBased, InclusiveEndIndexOnesBased)
        { }
    }
}