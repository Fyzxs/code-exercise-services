using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404RegularSingularPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 70;
        private const int InclusiveEndIndexOnesBased = 77;

        public TraderFoods404RegularSingularPrice(IRecord record) : base(record, StartIndexOnesBased, InclusiveEndIndexOnesBased)
        { }
    }
}