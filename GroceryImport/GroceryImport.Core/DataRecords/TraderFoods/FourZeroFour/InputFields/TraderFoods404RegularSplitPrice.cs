using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404RegularSplitPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 88;
        private const int InclusiveEndIndexOnesBased = 95;

        public TraderFoods404RegularSplitPrice(IRecord record) : base(record, StartIndexOnesBased, InclusiveEndIndexOnesBased)
        { }
    }
}